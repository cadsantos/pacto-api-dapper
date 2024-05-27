
using Fiotec.Pacto.Domain.DTOs.SolicitacoesMudanca;
using Fiotec.Pacto.Domain.Models.ViewModels.SolicitacoesMudancas;

namespace Fiotec.Pacto.Domain.Mappers.SolicitacoesMudanca
{
    public static class SolicitacaoMudancaPendenteMapper
    {
        public static SolicitacaoMudancaPendenteViewModel MapFromDTO(SolicitacaoMudancaPendenteDTO mudanca)
        {
            return new SolicitacaoMudancaPendenteViewModel
            {
                DocumentoKey = mudanca.DocumentoKey.ToString(),
                AssinaturaKey = mudanca.AssinaturaKey.ToString(),
                SolicitacaoMudancaKey = mudanca.SolicitacaoMudancaKey.ToString(),
                Titulo = mudanca.TituloDocumento,
                TipoMudanca = mudanca.TipoAlteracao,
                Descricao = mudanca.DescricaoDocumento,
                Solicitante = mudanca.NomeAssinante,
                Justificativa = mudanca.Justificativa
            };
        }
    }
}
