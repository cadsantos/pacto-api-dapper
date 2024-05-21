using Fiotec.Pacto.Domain.Entities.Dicionarios;

namespace Fiotec.Pacto.Domain.Ports.Driven.Dicionarios
{
    public interface IDicionarioRepository
    {
        Task<IReadOnlyList<TipoAssinatura>> ObterTiposAssinaturas(CancellationToken cancellationToken);
        Task<IReadOnlyList<TipoFinalizacao>> ObterTiposFinalizacoes(CancellationToken cancellationToken);
        Task<IReadOnlyList<StatusAssinatura>> ObterStatusAssianturas(CancellationToken cancellationToken);
        Task<IReadOnlyList<TipoAlteracao>> ObterTiposAlteracoes(CancellationToken cancellationToken);
        Task<IReadOnlyList<TipoAlteracao>> ObterTiposAlteracoesPorTipoResponsavel(char tipoResponsavel, CancellationToken cancellationToken);
    }
}
