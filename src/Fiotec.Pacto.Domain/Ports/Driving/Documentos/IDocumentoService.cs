using Fiotec.Pacto.Domain.Models.ViewModels.Documentos;

namespace Fiotec.Pacto.Domain.Ports.Driving.Documentos
{
    public interface IDocumentoService
    {
        Task<IEnumerable<DocumentoPendenteAssinaturaViewModel>> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken);
        Task<IEnumerable<DocumentoPendenteFinalizacaoManualViewModel>> ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(int idUsuario, CancellationToken cancellationToken);
        Task<IEnumerable<DocumentoAdministracaoViewModel>> ObterDocumentosAdministracaoPorIdUsuario(int idUsuario, CancellationToken cancellationToken);
        Task<DocumentoViewModel> ObterDocumentoDetalhesPorKey(Guid key, CancellationToken cancellationToken);
        Task<IEnumerable<DocumentoHistoricoViewModel>> ObterDocumentoHistoricoPorKey(Guid key, CancellationToken cancellationToken);
        Task<DocumentoArquivoViewModel?> ObterDocumentoArquivoPorKey(Guid key, int tipoDownload, CancellationToken cancellationToken);
    }
}
