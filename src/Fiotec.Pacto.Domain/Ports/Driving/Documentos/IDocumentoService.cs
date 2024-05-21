using Fiotec.Pacto.Domain.Models.ViewModels.Documentos;

namespace Fiotec.Pacto.Domain.Ports.Driving.Documentos
{
    public interface IDocumentoService
    {
        Task<IEnumerable<PendenteAssinaturaViewModel>> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken);
        Task<IEnumerable<PendenteFinalizacaoManualViewModel>> ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(int idUsuario, CancellationToken cancellationToken);
        Task<DocumentoViewModel> ObterDocumentosDetalhesPorKey(Guid key, CancellationToken cancellationToken);
    }
}
