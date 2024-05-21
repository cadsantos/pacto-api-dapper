using Fiotec.Pacto.Domain.Ports.Driving.Dicionarios;
using Microsoft.AspNetCore.Mvc;

namespace Fiotec.Pacto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicionariosController : ControllerBase
    {
        private readonly IDicionarioService _dicionarioService;

        public DicionariosController(IDicionarioService dicionarioService)
        {
            _dicionarioService = dicionarioService;
        }

        [HttpGet("tipos-assinaturas")]
        public async Task<IActionResult> ObterTiposAssinaturasAsync(CancellationToken cancellationToken)
        {
            var tipos_assinaturas = await _dicionarioService.ObterTiposAssinaturas(cancellationToken);
            return Ok(tipos_assinaturas);
        }

        [HttpGet("tipos-finalizacoes")]
        public async Task<IActionResult> ObterTiposFinalizacoesAsync(CancellationToken cancellationToken)
        {
            var tipos_finalizacoes = await _dicionarioService.ObterTiposFinalizacoes(cancellationToken);
            return Ok(tipos_finalizacoes);
        }

        [HttpGet("status-assinaturas")]
        public async Task<IActionResult> ObterStatusAssinaturasAsync(CancellationToken cancellationToken)
        {
            var status_assinaturas = await _dicionarioService.ObterStatusAssinaturas(cancellationToken);
            return Ok(status_assinaturas);
        }

        [HttpGet("tipos-alteracoes")]
        public async Task<IActionResult> ObterTiposAlteracoesAsync(CancellationToken cancellationToken)
        {
            var tipos_alteracoes = await _dicionarioService.ObterTiposAlteracoes(cancellationToken);
            return Ok(tipos_alteracoes);
        }

        [HttpGet("{tipoResponsavel}/tipos-alteracoes")]
        public async Task<IActionResult> ObterTiposAlteracoesPorTipoResponsavelAsync(char tipoResponsavel, CancellationToken cancellationToken)
        {
            var tipos_alteracoes = await _dicionarioService.ObterTiposAlteracoesPorTipoResponsavel(tipoResponsavel, cancellationToken);
            return Ok(tipos_alteracoes);
        }
    }
}
