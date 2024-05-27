using Fiotec.Pacto.Domain.Ports.Driving.SolicitacoesMudanca;
using Microsoft.AspNetCore.Mvc;

namespace Fiotec.Pacto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacoesMudancaController(ISolicitacaoMudancaService solicitacaoMudancaService) : ControllerBase
    {
        [HttpGet("pendentes/{idUsuario}")]
        public async Task<IActionResult> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            var solicitacoes = await solicitacaoMudancaService.ObterDocumentosPendentesAssinaturaPorIdUsuario(idUsuario, cancellationToken);
            return Ok(solicitacoes);
        }

        [HttpGet("detalhes/{key}")]
        public async Task<IActionResult> ObterSolicitacaoMudancaDetalhesPorKey(Guid key, CancellationToken cancellationToken)
        {
            var detalhes = await solicitacaoMudancaService.ObterSolicitacaoMudancaDetalhesPorKey(key, cancellationToken);
            return Ok(detalhes);
        }
    }
}
