using Dapper;
using Fiotec.Pacto.Domain.DTOs.SolicitacoesMudanca;
using Fiotec.Pacto.Domain.Ports.Driven.SolicitacoesMudanca;
using Fiotec.Pacto.Infra.Data.Context.Abastraction;
using System.Collections.Immutable;
using System.Data;
using System.Data.SqlClient;

namespace Fiotec.Pacto.Infra.Data.Repositories.SolicitacoesMudanca
{
    public class SolicitacaoMudancaRepository(ISqlConnectionContext context) : ISolicitacaoMudancaRepository
    {
        public async Task<IReadOnlyList<SolicitacaoMudancaPendenteDTO>> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = context.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@IdUsuario", idUsuario);
            var mudancas_pendentes = await sqlConnection.QueryAsync<SolicitacaoMudancaPendenteDTO>(
                new CommandDefinition("sp_ObterSolicitacoesMudancaPendentesPorIdUsuario", parameters: parametros, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            return mudancas_pendentes.ToImmutableList();
        }

        public async Task<SolicitacaoMudancaDetalhesDTO> ObterSolicitacaoMudancaDetalhesPorKey(Guid key, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = context.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@Key", key);
            var mudanca_detalhes = await sqlConnection.QueryFirstAsync<SolicitacaoMudancaDetalhesDTO>(
                new CommandDefinition("sp_ObterSolicitacaoMudancaDetalhesPorKey", parameters: parametros, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));

            return mudanca_detalhes;
        }
    }
}
