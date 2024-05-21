using Fiotec.Pacto.Domain.Models.ViewModels.Dicionarios;

namespace Fiotec.Pacto.Domain.Ports.Driving.Dicionarios
{
    public interface IDicionarioService
    {
        Task<IEnumerable<TipoAssinaturaViewModel>> ObterTiposAssinaturas(CancellationToken cancellationToken);
        Task<IEnumerable<TipoFinalizacaoViewModel>> ObterTiposFinalizacoes(CancellationToken cancellationToken);
        Task<IEnumerable<TipoAlteracaoViewModel>> ObterTiposAlteracoes(CancellationToken cancellationToken);
        Task<IEnumerable<TipoAlteracaoViewModel>> ObterTiposAlteracoesPorTipoResponsavel(char tipoResponsavel, CancellationToken cancellationToken);
        Task<IEnumerable<StatusAssinaturaViewModel>> ObterStatusAssinaturas(CancellationToken cancellationToken);
    }
}
