using Fiotec.Pacto.Domain.Entities.Documentos;
using Fiotec.Pacto.Domain.Mappers.Documentos;
using Fiotec.Pacto.Domain.Models.ViewModels.Documentos;
using Fiotec.Pacto.Domain.Ports.Driven.Documentos;
using Fiotec.Pacto.Domain.Ports.Driving.Documentos;

namespace Fiotec.Pacto.Application.Services.Documentos
{
    public sealed class DocumentoService(IDocumentoRepository _documentoRepository) : IDocumentoService
    {
        public async Task<IEnumerable<PendenteAssinaturaViewModel>> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            var pendentes = await _documentoRepository.ObterDocumentosPendentesAssinaturaPorIdUsuario(idUsuario, cancellationToken);
            return pendentes.Select(PendenteAssinaturaMapper.MapFromDTO);
        }

        public async Task<IEnumerable<PendenteFinalizacaoManualViewModel>> ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            var pendentes_manual = await _documentoRepository.ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(idUsuario, cancellationToken);
            return pendentes_manual.Select(PendenteFinalizacaoManualMapper.MapFromDTO);
        }

        public async Task<DocumentoViewModel> ObterDocumentosDetalhesPorKey(Guid key, CancellationToken cancellationToken)
        {
            var documento_detalhes = await _documentoRepository.ObterDocumentoDetalhesPorKey(key, cancellationToken);            
            return DocumentoMapper.MapFromEntity(documento_detalhes);
        }
    }
}
