namespace Fiotec.Pacto.Domain.Ports.Driven.Services.Arquivos
{
    public interface IArquivoService
    {
        Task<byte[]> ObterArquivo(string caminhoArquivo);
    }
}
