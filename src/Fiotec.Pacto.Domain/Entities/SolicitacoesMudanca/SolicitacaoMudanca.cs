namespace Fiotec.Pacto.Domain.Entities.SolicitacoesMudanca
{
    public sealed class SolicitacaoMudanca
    {
        public int Id { get; set; }
        public int IdAssinatura { get; set; }
        public int IdTipoAlteracao { get; set; }
        public int IdStatus { get; set; }
        public int? IdTipoIdentificacao { get; set; }
        public int? IdAssinante { get; set; }
        public Guid Key { get; set; }
        public DateTime? DataPrazoAssinatura { get; set; }
        public DateTime DataCadastro { get; set; }
        public string? Justificativa { get; set; }
        public string? Identificacao { get; set; }
        public string? Qualificacao { get; set; }
        public bool Excluido { get; set; }
    }
}
