using Fiotec.Pacto.Domain.Ports.Driving.Documentos;
using Microsoft.AspNetCore.Mvc;

namespace Fiotec.Pacto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private readonly IDocumentoService _documentoService;

        public DocumentosController(IDocumentoService documentoService)
        {
            _documentoService = documentoService;
        }

        [HttpGet("pendentes/{idUsuario}")]
        public async Task<IActionResult> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            var pendentes = await _documentoService.ObterDocumentosPendentesAssinaturaPorIdUsuario(idUsuario, cancellationToken);
            return Ok(pendentes);
        }

        [HttpGet("finalizacao-manual/{idUsuario}")]
        public async Task<IActionResult> ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            var pendentes = await _documentoService.ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(idUsuario, cancellationToken);
            return Ok(pendentes);
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> ObterDocumentosDetalhesPorKey(Guid key, CancellationToken cancellationToken)
        {
            var pendentes = await _documentoService.ObterDocumentosDetalhesPorKey(key, cancellationToken);
            return Ok(pendentes);
        }
    }
}
