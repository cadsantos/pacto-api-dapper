using Fiotec.Pacto.Domain.DTOs.SolicitacoesMudanca;
using Fiotec.Pacto.Domain.Models.ViewModels.SolicitacoesMudancas;

namespace Fiotec.Pacto.Domain.Mappers.SolicitacoesMudanca
{
    public static class SolicitacaoMudancaMapper
    {
        public static SolicitacaoMudancaViewModel MapFromDTO(SolicitacaoMudancaDetalhesDTO dto)
        {
            return new SolicitacaoMudancaViewModel
            {
                SolicitacaoMudancaKey = dto.Key.ToString(),
                DocumentoKey = dto.DocumentoKey.ToString(),
                AssinaturaKey = dto.AssinaturaKey.ToString(),
                IdTipoAlteracao = dto.IdTipoAlteracao,
                TipoAlteracao = dto.NomeAlteracao,
                Status = dto.StatusMudancaDescricao,
                Justificativa = dto.SolicitacaoMudancaJustificativa,
                PrazoAssinatura = dto.AssinaturaDataPrazoAssinatura.ToString(),
                NovoPrazoAssinatura = dto.SolicitacaoMudancaNovaDataPrazoAssinatura.ToString(),
                Assinante = dto.AssinaturaIdAssinante.ToString(),
                NovoAssinante = dto.SolicitacaoMudancaNovoIdAssinante.ToString(),
                Qualificacao = dto.AssinaturaQualificacao,
                NovaQualificacao = dto.SolicitacaoMudancaNovaQualificacao,
                Identificacao = dto.AssinaturaIdentificacao,
                NovaIdentificacao = dto.SolicitacaoMudancaNovaIdentificacao,
                TipoIdentificacao = dto.TipoIdentificacao,
                NovoTipoIdentificacao = dto.SolicitacaoMudancaNovaIdentificacao
            };
        }
    }
}
