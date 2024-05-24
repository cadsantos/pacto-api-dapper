using Fiotec.Pacto.Domain.Entities.Documentos;
using Fiotec.Pacto.Domain.Enums;
using Fiotec.Pacto.Domain.Mappers.Documentos;
using Fiotec.Pacto.Domain.Models.ViewModels.Documentos;
using Fiotec.Pacto.Domain.Ports.Driven.Documentos;
using Fiotec.Pacto.Domain.Ports.Driven.Services.Historicos;
using Fiotec.Pacto.Domain.Ports.Driving.Documentos;
using System.Linq;

namespace Fiotec.Pacto.Application.Services.Documentos
{
    public sealed class DocumentoService(
        IDocumentoRepository _documentoRepository,
        IHistoricoService _historicoService) : IDocumentoService
    {
        private const int ID_USUARIO = 9152;

        public async Task<IEnumerable<PendenteAssinaturaViewModel>> ObterDocumentosPendentesAssinaturaPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            var pendentes = await _documentoRepository.ObterDocumentosPendentesAssinaturaPorIdUsuario(idUsuario, cancellationToken);
            return pendentes.Select(PendenteAssinaturaMapper.MapFromDTO);
        }
        
        public async Task<IEnumerable<PendenteFinalizacaoManualViewModel>> ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(int idUsuario, CancellationToken cancellationToken)
        {
            var pendentes_manual = await _documentoRepository.ObterDocumentosPendentesFinalizacaoManualPorIdUsuario(idUsuario, cancellationToken);
            return pendentes_manual.Select(PendenteFinalizacaoManualMapper.MapFromDTO);
        }
        
        public async Task<DocumentoViewModel> ObterDocumentoDetalhesPorKey(Guid key, CancellationToken cancellationToken)
        {
            var documento = await _documentoRepository.ObterDocumentoDetalhesPorKey(key, cancellationToken);

            if (documento is null)
                return new DocumentoViewModel();

            var documentoDetalhes = DocumentoMapper.MapFromEntity(documento);
            bool proprietario = documento.IsProprietario(ID_USUARIO);
            bool proprietarioAssinante = documento.IsProprietarioAssinante(ID_USUARIO);
            bool nenhumaAssinaturaRealizada = documento.IsNenhumaAssinaturaRealizada();
            bool assinadoParcialmente = documento.IsAssinadoParcialmente();
            bool assinadoTotalmente = documento.IsAssinadoTotalmente();
            bool documentoFinalizado = documento.IsFinalizado();
            bool documentoDeclinadoExpirado = documento.IsDeclinadoExpirado();
            bool documentoSolicitacaoMudanca = true;

            if (proprietario)
            {
                if (proprietarioAssinante)
                {
                    if (nenhumaAssinaturaRealizada)
                    {
                        documentoDetalhes.HabilitaBotaoAssinar = true;
                        documentoDetalhes.HabilitaBotaoDeclinar = true;
                        documentoDetalhes.HabilitaBotaoUploadAssinatura = true;
                        documentoDetalhes.HabilitaBotaoSolicitarMudanca = true;
                        documentoDetalhes.HabilitaEditarAssinante = true;
                        documentoDetalhes.HabilitaSubstituirAssinante = true;
                        documentoDetalhes.HabilitaDelegarAssinante = true;
                        documentoDetalhes.HabilitaAvocarAssinatura = true;
                        documentoDetalhes.HabilitaExcluirAssinante = true;
                        documentoDetalhes.HabilitaSubstituirAnexo = true;
                        documentoDetalhes.HabilitaExcluirDocumento = true;
                        documentoDetalhes.HabilitaInserirAssinante = true;
                    }

                    if (assinadoParcialmente)
                    {
                        documentoDetalhes.HabilitaBotaoUploadAssinatura = true;
                        documentoDetalhes.HabilitaEditarAssinante = true;
                        documentoDetalhes.HabilitaSubstituirAssinante = true;
                        documentoDetalhes.HabilitaDelegarAssinante = true;
                        documentoDetalhes.HabilitaAvocarAssinatura = true;
                        documentoDetalhes.HabilitaExcluirAssinante = true;
                        documentoDetalhes.HabilitaSubstituirAnexo = true;
                        documentoDetalhes.HabilitaExcluirDocumento = true;
                        documentoDetalhes.HabilitaInserirAssinante = true;
                    }

                    if (assinadoTotalmente)
                    {
                        if (proprietario && documento.IdTipoFinalizacao == (int)ETipoFinalizacao.Manual && documento.IdStatus == (int)EStatusAssinatura.NaoAssinado)
                        {
                            documentoDetalhes.HabilitaBotaoFinalizaoManual = true;

                            if (documento.DataPrazoFinalizacao is not null && documento.DataPrazoFinalizacao.Value.Date >= DateTime.Now.Date)
                                documentoDetalhes.HabilitaInserirAssinante = true;
                        }
                    }

                    if (documentoFinalizado || documentoDeclinadoExpirado)
                        documentoDetalhes.HabilitaBotaoDownloadAssinado = true;

                    if (documentoSolicitacaoMudanca)
                    {
                        documentoDetalhes.HabilitaBotaoAssinar = false;
                        documentoDetalhes.HabilitaBotaoDeclinar = false;
                        documentoDetalhes.HabilitaBotaoExcluir = false;
                        documentoDetalhes.HabilitaBotaoUploadAssinatura = false;
                        documentoDetalhes.HabilitaBotaoSolicitarMudanca = false;
                        documentoDetalhes.HabilitaEditarAssinante = false;
                        documentoDetalhes.HabilitaSubstituirAssinante = false;
                        documentoDetalhes.HabilitaDelegarAssinante = false;
                        documentoDetalhes.HabilitaAvocarAssinatura = false;
                        documentoDetalhes.HabilitaExcluirAssinante = false;
                        documentoDetalhes.HabilitaSubstituirAnexo = false;
                    }
                }
                else
                {
                    if (nenhumaAssinaturaRealizada || assinadoParcialmente)
                    {
                        documentoDetalhes.HabilitaBotaoExcluir = true;
                        documentoDetalhes.HabilitaBotaoUploadAssinatura = true;
                        documentoDetalhes.HabilitaEditarAssinante = true;
                        documentoDetalhes.HabilitaSubstituirAssinante = true;
                        documentoDetalhes.HabilitaDelegarAssinante = true;
                        documentoDetalhes.HabilitaAvocarAssinatura = true;
                        documentoDetalhes.HabilitaExcluirAssinante = true;
                        documentoDetalhes.HabilitaSubstituirAnexo = true;
                        documentoDetalhes.HabilitaExcluirDocumento = true;
                        documentoDetalhes.HabilitaInserirAssinante = true;
                    }

                    if (assinadoTotalmente)
                    {
                        if (proprietario && documento.IdTipoFinalizacao == (int)ETipoFinalizacao.Manual && documento.IdStatus == (int)EStatusAssinatura.NaoAssinado)
                        {
                            documentoDetalhes.HabilitaBotaoFinalizaoManual = true;

                            if (documento.DataPrazoFinalizacao is not null && documento.DataPrazoFinalizacao.Value.Date >= DateTime.Now.Date)
                                documentoDetalhes.HabilitaInserirAssinante = true;
                        }
                    }

                    if (documentoFinalizado || documentoDeclinadoExpirado)
                        documentoDetalhes.HabilitaBotaoDownloadAssinado = true;

                    if (documentoSolicitacaoMudanca)
                    {
                        documentoDetalhes.HabilitaBotaoAssinar = false;
                        documentoDetalhes.HabilitaBotaoDeclinar = false;
                        documentoDetalhes.HabilitaBotaoExcluir = false;
                        documentoDetalhes.HabilitaBotaoUploadAssinatura = false;
                        documentoDetalhes.HabilitaBotaoSolicitarMudanca = false;

                        documentoDetalhes.HabilitaEditarAssinante = false;
                        documentoDetalhes.HabilitaSubstituirAssinante = false;
                        documentoDetalhes.HabilitaDelegarAssinante = false;
                        documentoDetalhes.HabilitaAvocarAssinatura = false;
                        documentoDetalhes.HabilitaExcluirAssinante = false;
                        documentoDetalhes.HabilitaSubstituirAnexo = false;
                    }
                }
            }
            else
            {
                if (nenhumaAssinaturaRealizada || assinadoParcialmente)
                {
                    if (!documento.HabilitadoOrdemAssinatura)
                    {
                        documentoDetalhes.HabilitaBotaoAssinar = true;
                        documentoDetalhes.HabilitaBotaoDeclinar = true;
                        documentoDetalhes.HabilitaBotaoSolicitarMudanca = true;
                    }
                    else
                    {
                        if (documento.Assinaturas
                            .Where(a => a.IdStatus == (int)EStatusAssinatura.NaoAssinado && a.IdAssinante == ID_USUARIO)
                            .OrderBy(o => o.Ordem)
                            .Any())
                        {
                            documentoDetalhes.HabilitaBotaoAssinar = true;
                            documentoDetalhes.HabilitaBotaoDeclinar = true;
                            documentoDetalhes.HabilitaBotaoSolicitarMudanca = true;
                        }
                    }
                }

                if (documentoFinalizado)
                    documentoDetalhes.HabilitaBotaoDownloadAssinado = true;
            }

            var historicos = await _historicoService.ObterHistoricoDocumento(documento.Key);
            historicos?.Result?.ForEach(historico => documentoDetalhes.Historicos.Add(new HistoricoDocumentoViewModel()
            {
                UsuarioId = historico.UserLoginId.HasValue ? historico.UserLoginId.Value : 0,
                KeyDocumento = documento.Key,
                NomeUsuario = historico.UserLoginName,
                DataInclusao = historico.DateTimeCreate.ToString(),
                Status = historico.SystemStatusDetail,
                Descricao = historico.Justification,
                ProcessoDescricao = historico.ProcessDetail
            }));
            return documentoDetalhes;
        }

        public async Task<IEnumerable<HistoricoDocumentoViewModel>> ObterDocumentoHistoricoPorKey(Guid key, CancellationToken cancellationToken)
        {
            var historicos_servico = await _historicoService.ObterHistoricoDocumento(key);

            if (historicos_servico is null)
                return new List<HistoricoDocumentoViewModel>();

            return (from item in historicos_servico.Result
                    let hist = new HistoricoDocumentoViewModel()
                    {
                        UsuarioId = item.UserLoginId.HasValue ? item.UserLoginId.Value : 0,
                        KeyDocumento = Guid.Parse(item.InstanceKey),
                        NomeUsuario = item.UserLoginName,
                        DataInclusao = item.DateTimeCreate.ToString(),
                        Status = item.SystemStatusDetail,
                        Descricao = item.Justification,
                        ProcessoDescricao = item.ProcessDetail
                    }
                    select hist).ToList();
        }
    }
}
