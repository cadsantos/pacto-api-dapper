using Fiotec.Pacto.Domain.Models.ViewModels.SolicitacoesMudancas;

namespace Fiotec.Pacto.Domain.Ports.Driving.SolicitacoesMudanca
{
    public interface ISolicitacaoMudancaService
    {
        Task<IEnumerable<SolicitacaoMudancaPendenteViewModel>> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken);
        Task<SolicitacaoMudancaViewModel> ObterSolicitacaoMudancaDetalhesPorKey(Guid key, CancellationToken cancellationToken);
    }
}
