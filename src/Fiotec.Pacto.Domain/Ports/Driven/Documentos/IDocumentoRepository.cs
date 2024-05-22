using Fiotec.Pacto.Domain.DTOs.Documentos;
using Fiotec.Pacto.Domain.Entities.Documentos;

namespace Fiotec.Pacto.Domain.Ports.Driven.Documentos
{
    public interface IDocumentoRepository
    {
        Task<IReadOnlyList<PendenteAssinaturaDTO>> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken);
        Task<IReadOnlyList<PendenteFinalizacaoManualDTO>> ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(int idUsuario, CancellationToken cancellationToken);
        Task<Documento?> ObterDocumentoDetalhesPorKey(Guid key, CancellationToken cancellationToken);
    }
}
