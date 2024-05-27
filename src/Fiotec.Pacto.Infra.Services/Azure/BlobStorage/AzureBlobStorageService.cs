using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Fiotec.Pacto.Domain.Ports.Driven.Services.Azure.BlobStorage;
using Microsoft.Extensions.Configuration;

namespace Fiotec.Pacto.Infra.Services.Azure.BlobStorage
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _blobServiceContainer;
        private readonly StorageSharedKeyCredential _userDelegationKey;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _userDelegationKey = new StorageSharedKeyCredential(_configuration["Services:Azure:BlobStorage:Account"], _configuration["Services:Azure:BlobStorage:Key"]);
            //var blobUri = new Uri($"https://{_configuration["Azure:BlobStorage:Account"]}.blob.core.windows.net");
            var blobUri = new Uri($"http://127.0.0.1:10000/{_configuration["Services:Azure:BlobStorage:Account"]}");
            _blobServiceClient = new BlobServiceClient(blobUri, _userDelegationKey);
            _blobServiceContainer = _blobServiceClient.GetBlobContainerClient(_configuration["Services:Azure:BlobStorage:Container"]);
        }

        public async Task<byte[]> DownloadAsync(string path)
        {
            var client = _blobServiceContainer.GetBlockBlobClient(path);

            try
            {
                if (!await client.ExistsAsync())
                    throw new Exception($"Arquivo não encontrado: {path}");

                var response = await client.DownloadAsync();
                using var memStream = new MemoryStream();
                await response.Value.Content.CopyToAsync(memStream);
                return memStream.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar fazer o download do arquivo: {path}. Detalhes: {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<List<string>> ObtemLinkDonwload(string nomeArquivo)
        {
            var arquivosUrl = new List<string>();
            var container = _blobServiceClient.GetBlobContainerClient(_configuration["Azure:BlobStorage:Container"]);
            var blobs = container.GetBlobsAsync();

            await foreach (var blob in blobs)
            {
                if (blob.Name.Contains(nomeArquivo))
                {
                    var blobClient = container.GetBlobClient(blob.Name);
                    var url = blobClient.Uri.AbsoluteUri;
                    var userDelegationKey = _userDelegationKey;
                    string? storedPolicyName = null;
                    var sasBuilder = new BlobSasBuilder()
                    {
                        BlobContainerName = container.Name,
                        BlobName = blob.Name,
                        Resource = "b",
                        StartsOn = DateTimeOffset.UtcNow,
                        ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(60)
                    };

                    if (storedPolicyName == null)
                    {
                        sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddDays(1);
                        sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);
                    }
                    else
                    {
                        sasBuilder.Identifier = storedPolicyName;
                    }

                    var blobUriBuilder = new BlobUriBuilder(container.Uri)
                    {
                        Sas = sasBuilder.ToSasQueryParameters(userDelegationKey),
                    };
                    arquivosUrl.Add($"{url}?{blobUriBuilder.Sas}");
                }
            }
            return arquivosUrl;
        }
    }
}
