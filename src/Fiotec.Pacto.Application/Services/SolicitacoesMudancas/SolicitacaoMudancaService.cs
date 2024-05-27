using Fiotec.Pacto.Domain.Mappers.SolicitacoesMudanca;
using Fiotec.Pacto.Domain.Models.ViewModels.SolicitacoesMudancas;
using Fiotec.Pacto.Domain.Ports.Driven.SolicitacoesMudanca;
using Fiotec.Pacto.Domain.Ports.Driving.SolicitacoesMudanca;

namespace Fiotec.Pacto.Application.Services.SolicitacoesMudancas
{
    public class SolicitacaoMudancaService(ISolicitacaoMudancaRepository solicitacaoMudancaRepository) : ISolicitacaoMudancaService
    {
        public async Task<IEnumerable<SolicitacaoMudancaPendenteViewModel>> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            var pendentes = await solicitacaoMudancaRepository.ObterDocumentosPendentesAssinaturaPorIdUsuario(idUsuario, cancellationToken);
            return pendentes.Select(SolicitacaoMudancaPendenteMapper.MapFromDTO);
        }

        public async Task<SolicitacaoMudancaViewModel> ObterSolicitacaoMudancaDetalhesPorKey(Guid key, CancellationToken cancellationToken)
        {
            var detalhes = await solicitacaoMudancaRepository.ObterSolicitacaoMudancaDetalhesPorKey(key, cancellationToken);
            return SolicitacaoMudancaMapper.MapFromDTO(detalhes);
        }
    }
}
