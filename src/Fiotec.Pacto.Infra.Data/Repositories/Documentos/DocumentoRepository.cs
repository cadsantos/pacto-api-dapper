using Dapper;
using Fiotec.Pacto.Domain.DTOs.Documentos;
using Fiotec.Pacto.Domain.Entities.Assinaturas;
using Fiotec.Pacto.Domain.Entities.Dicionarios;
using Fiotec.Pacto.Domain.Entities.Documentos;
using Fiotec.Pacto.Domain.Ports.Driven.Documentos;
using Fiotec.Pacto.Infra.Data.Context.Abastraction;
using System.Collections.Immutable;
using System.Data;
using System.Data.SqlClient;

namespace Fiotec.Pacto.Infra.Data.Repositories.Documentos
{
    public sealed class DocumentoRepository(ISqlConnectionContext context) : IDocumentoRepository
    {
        public async Task<IReadOnlyList<PendenteAssinaturaDTO>> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = context.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@IdUsuario", idUsuario);
            var pendentes_assinatura = await sqlConnection.QueryAsync<PendenteAssinaturaDTO>(
                new CommandDefinition("sp_ObterDocumentosAguardandoAssinaturaPorIdUsuario", parameters: parametros, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            return pendentes_assinatura.ToImmutableList();
        }

        public async Task<IReadOnlyList<PendenteFinalizacaoManualDTO>> ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = context.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@IdUsuario", idUsuario);
            var pendentes_assinatura = await sqlConnection.QueryAsync<PendenteFinalizacaoManualDTO>(
                new CommandDefinition("sp_ObterDocumentosAguardandoFinalizacaoManualPorIdUsuario", parameters: parametros, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            return pendentes_assinatura.ToImmutableList();
        }

        public async Task<Documento?> ObterDocumentoDetalhesPorKey(Guid key, CancellationToken cancellationToken)
        {
            Dictionary<int, Documento> documentosDictionary = new();

            await using SqlConnection sqlConnection = context.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@DocumentoKey", key);

            var documento_detalhe = await sqlConnection.QueryAsync<Documento, Assinatura, TipoAssinatura, StatusAssinatura, TipoFinalizacao, TipoIdentificacao, StatusAssinatura, Documento>
                ("sp_ObterDocumentoPorKey", (d, a, ta, sd, tf, ti, sa) =>
                {
                    if (ta != null) d.TipoAssinatura = ta;
                    if (sd != null) d.StatusDocumento = sd;
                    if (tf != null) d.TipoFinalizacao = tf;
                    if (ti != null) a.TipoIdentificacao = ti;
                    if (sa != null) a.StatusAssinatura = sa;

                    if (documentosDictionary.TryGetValue(d.Id, out var documentoEncontrado))
                        d = documentoEncontrado;
                    else
                        documentosDictionary.Add(d.Id, d);
                    d.Assinaturas.Add(a);
                    return d;
                }, new
                {
                    DocumentoKey = key
                }, splitOn: "Id,Id,Id,Id,Id,Id,Id", commandType: CommandType.StoredProcedure);

            return documento_detalhe.GroupBy(d => d.Id).Select(g => g.First()).FirstOrDefault();
        }

        public async Task<IReadOnlyList<DocumentoAdministracaoDTO>> ObterDocumentosAdministracaoPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            await using SqlConnection sqlConnection = context.CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@IdUsuario", idUsuario);
            var documentos_administracao = await sqlConnection.QueryAsync<DocumentoAdministracaoDTO>(
                new CommandDefinition("sp_ObterDocumentosAdministracaoPorIdUsuario", parameters: parametros, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken));
            return documentos_administracao.ToImmutableList();
        }
    }
}
