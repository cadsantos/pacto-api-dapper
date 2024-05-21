using Dapper;
using Fiotec.Pacto.Domain.Entities.Dicionarios;
using Fiotec.Pacto.Domain.Ports.Driven.Dicionarios;
using Fiotec.Pacto.Infra.Data.Context.Abastraction;
using System.Collections.Immutable;
using System.Data;
using System.Data.SqlClient;

namespace Fiotec.Pacto.Infra.Data.Repositories.Dicionarios
{
    public sealed class DicionarioRepository(ISqlConnectionContext _sqlConnection) : IDicionarioRepository
    {
        public async Task<IReadOnlyList<TipoAssinatura>> ObterTiposAssinaturas(CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _sqlConnection.CreateConnection();
            var tipos_assinaturas = await sqlConnection.QueryAsync<TipoAssinatura>(
                new CommandDefinition("sp_ObterTiposAssinaturas", commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            return tipos_assinaturas.ToImmutableList();
        }

        public async Task<IReadOnlyList<TipoFinalizacao>> ObterTiposFinalizacoes(CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _sqlConnection.CreateConnection();
            var tipos_finalizacoes = await sqlConnection.QueryAsync<TipoFinalizacao>(
                new CommandDefinition("sp_ObterTiposFinalizacoes", commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            return tipos_finalizacoes.ToImmutableList();
        }

        public async Task<IReadOnlyList<StatusAssinatura>> ObterStatusAssianturas(CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _sqlConnection.CreateConnection();
            var status_assinaturas = await sqlConnection.QueryAsync<StatusAssinatura>(
                new CommandDefinition("sp_ObterStatusAssinaturas", commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            return status_assinaturas.ToImmutableList();
        }

        public async Task<IReadOnlyList<TipoAlteracao>> ObterTiposAlteracoes(CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _sqlConnection.CreateConnection();
            var tipos_alteracoes = await sqlConnection.QueryAsync<TipoAlteracao>(
                new CommandDefinition("sp_ObterTiposAlteracoes", commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            return tipos_alteracoes.ToImmutableList();
        }

        public async Task<IReadOnlyList<TipoAlteracao>> ObterTiposAlteracoesPorTipoResponsavel(char tipoResponsavel, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _sqlConnection.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@TipoResponsavel", tipoResponsavel);
            var tipos_alteracoes = await sqlConnection.QueryAsync<TipoAlteracao>(
                new CommandDefinition("sp_ObterTiposAlteracoesPorTipoResponsavel", parameters: parametros, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            return tipos_alteracoes.ToImmutableList();
        }
    }
}
