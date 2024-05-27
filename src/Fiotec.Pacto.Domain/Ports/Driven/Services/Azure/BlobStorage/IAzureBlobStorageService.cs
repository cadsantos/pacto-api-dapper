namespace Fiotec.Pacto.Domain.Ports.Driven.Services.Azure.BlobStorage
{
    public interface IAzureBlobStorageService
    {
        Task<byte[]> DownloadAsync(string caminhoRelativo);
        Task<List<string>> ObtemLinkDonwload(string nomeArquivo);
    }
}
