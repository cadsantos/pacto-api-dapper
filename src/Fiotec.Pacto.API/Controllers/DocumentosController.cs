using Fiotec.Pacto.Domain.Ports.Driving.Documentos;
using Microsoft.AspNetCore.Mvc;

namespace Fiotec.Pacto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController(IDocumentoService documentoService) : ControllerBase
    {
        [HttpGet("{key}")]
        public async Task<IActionResult> ObterDocumentosDetalhesPorKey(Guid key, CancellationToken cancellationToken)
        {
            var pendentes = await documentoService.ObterDocumentoDetalhesPorKey(key, cancellationToken);
            return Ok(pendentes);
        }

        [HttpGet("{key}/historico")]
        public async Task<IActionResult> ObterDocumentosHistoricoPorKey(Guid key, CancellationToken cancellationToken)
        {
            var pendentes = await documentoService.ObterDocumentoHistoricoPorKey(key, cancellationToken);
            return Ok(pendentes);
        }

        [HttpGet("{key}/download")]
        public async Task<IActionResult> GetDownloadArquivo(Guid key, int d, CancellationToken cancellationToken)
        {
            var arquivo = await documentoService.ObterDocumentoArquivoPorKey(key, d, cancellationToken);

            if (arquivo is null && arquivo?.Arquivo is null)
                return NotFound();

            return new FileContentResult(arquivo.Arquivo, "application/pdf")
            {
                FileDownloadName = arquivo.Nome
            };
        }

        [HttpGet("pendentes/{idUsuario}")]
        public async Task<IActionResult> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            var pendentes = await documentoService.ObterDocumentosPendentesAssinaturaPorIdUsuario(idUsuario, cancellationToken);
            return Ok(pendentes);
        }

        //[HttpGet("tramitantes/{idUsuario}")]
        //public async Task<IActionResult> ObterDocumentosTramitantesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        //{
        //    var pendentes = await documentoService.ObterDocumentosPendentesAssinaturaPorIdUsuario(idUsuario, cancellationToken);
        //    return Ok(pendentes);
        //}

        [HttpGet("finalizacao-manual/{idUsuario}")]
        public async Task<IActionResult> ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            var pendentes = await documentoService.ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(idUsuario, cancellationToken);
            return Ok(pendentes);
        }

        [HttpGet("administracao/{idUsuario}")]
        public async Task<IActionResult> ObterDocumentosAdministracaoPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            var pendentes = await documentoService.ObterDocumentosAdministracaoPorIdUsuario(idUsuario, cancellationToken);
            return Ok(pendentes);
        }


    }
}
