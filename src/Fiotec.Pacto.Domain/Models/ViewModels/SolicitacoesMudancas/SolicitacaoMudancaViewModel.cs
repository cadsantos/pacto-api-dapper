namespace Fiotec.Pacto.Domain.Models.ViewModels.SolicitacoesMudancas
{
    public class SolicitacaoMudancaViewModel
    {
        public string? SolicitacaoMudancaKey { get; set; }
        public string? DocumentoKey { get; set; }
        public string? AssinaturaKey { get; set; }
        public int IdTipoAlteracao { get; set; }
        public string? TipoAlteracao { get; set; }
        public string? Status { get; set; }
        public string? Justificativa { get; set; }
        public string? PrazoAssinatura { get; set; }
        public string? NovoPrazoAssinatura { get; set; }
        public string? Assinante { get; set; }
        public string? NovoAssinante { get; set; }
        public string? Qualificacao { get; set; }
        public string? NovaQualificacao { get; set; }
        public string? Identificacao { get; set; }
        public string? NovaIdentificacao { get; set; }
        public string? TipoIdentificacao { get; set; }
        public string? NovoTipoIdentificacao { get; set; }
    }
}
