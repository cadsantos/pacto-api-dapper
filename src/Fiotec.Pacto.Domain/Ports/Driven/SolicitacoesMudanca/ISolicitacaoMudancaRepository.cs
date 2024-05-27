using Fiotec.Pacto.Domain.DTOs.SolicitacoesMudanca;

namespace Fiotec.Pacto.Domain.Ports.Driven.SolicitacoesMudanca
{
    public interface ISolicitacaoMudancaRepository
    {
        Task<IReadOnlyList<SolicitacaoMudancaPendenteDTO>> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken);
        Task<SolicitacaoMudancaDetalhesDTO> ObterSolicitacaoMudancaDetalhesPorKey(Guid key, CancellationToken cancellationToken);
    }
}
