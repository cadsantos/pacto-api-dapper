using Fiotec.Pacto.Domain.Ports.Driven.Services.Arquivos;

namespace Fiotec.Pacto.Infra.Services.Arquivos
{
    public class ArquivoService : IArquivoService
    {
        public async Task<byte[]> ObterArquivo(string caminhoArquivo)
        {
            using FileStream fileStream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
            byte[] array = new byte[fileStream.Length];
            await fileStream.ReadAsync(array, 0, (int)fileStream.Length);
            return array;
        }
    }
}
