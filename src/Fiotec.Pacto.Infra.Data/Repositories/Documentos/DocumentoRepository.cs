using Dapper;
using Fiotec.Pacto.Domain.DTOs.Documentos;
using Fiotec.Pacto.Domain.Entities.Assinaturas;
using Fiotec.Pacto.Domain.Entities.Dicionarios;
using Fiotec.Pacto.Domain.Entities.Documentos;
using Fiotec.Pacto.Domain.Ports.Driven.Documentos;
using Fiotec.Pacto.Infra.Data.Context.Abastraction;
using System.Collections.Immutable;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace Fiotec.Pacto.Infra.Data.Repositories.Documentos
{
    public sealed class DocumentoRepository(ISqlConnectionContext _sqlConnection) : IDocumentoRepository
    {
        public async Task<IReadOnlyList<PendenteAssinaturaDTO>> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _sqlConnection.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@IdUsuario", idUsuario);
            var pendentes_assinatura = await sqlConnection.QueryAsync<PendenteAssinaturaDTO>(
                new CommandDefinition("sp_ObterDocumentosAguardandoAssinaturaPorIdUsuario", parameters: parametros, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            return pendentes_assinatura.ToImmutableList();
        }

        public async Task<IReadOnlyList<PendenteFinalizacaoManualDTO>> ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = _sqlConnection.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@IdUsuario", idUsuario);
            var pendentes_assinatura = await sqlConnection.QueryAsync<PendenteFinalizacaoManualDTO>(
                new CommandDefinition("sp_ObterDocumentosAguardandoFinalizacaoManualPorIdUsuario", parameters: parametros, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            return pendentes_assinatura.ToImmutableList();
        }

        public async Task<Documento> ObterDocumentoDetalhesPorKey(Guid key, CancellationToken cancellationToken)
        {
            Dictionary<int, Documento> documentosDictionary = new();

            await using SqlConnection sqlConnection = _sqlConnection.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@DocumentoKey", key);

            //var documento_detalhes = await sqlConnection.QueryAsync<Documento>(
            //    new CommandDefinition("sp_ObterDocumentoPorKey", parameters: parametros, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            var documento_detalhe = await sqlConnection.QueryAsync<Documento, Assinatura, Documento>
                ("sp_ObterDocumentoPorKey", (d, a) =>
                {
                    if (documentosDictionary.TryGetValue(d.Id, out var documentoEncontrado))
                        d = documentoEncontrado;
                    else
                        documentosDictionary.Add(d.Id, d);
                    d.Assinaturas.Add(a);
                    return d;
                }, new
                {
                    DocumentoKey = key                    
                }, splitOn: "Id,Id,Id", commandType: CommandType.StoredProcedure);

            //return documento_detalhes.ToImmutableList();
            return documento_detalhe.GroupBy(d => d.Id).Select(g => g.First()).FirstOrDefault();
        }
    }
}
