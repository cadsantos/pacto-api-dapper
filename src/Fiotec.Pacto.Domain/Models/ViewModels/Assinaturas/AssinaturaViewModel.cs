namespace Fiotec.Pacto.Domain.Models.ViewModels.Assinaturas
{
    public class AssinaturaViewModel
    {
        public int Id { get; set; }
        public int IdDocumento { get; set; }
        public int? IdAssinante { get; set; }
        public Guid Key { get; set; }
        public int? Ordem { get; set; }
        public string? NomeAssinante { get; set; }
        public int IdStatus { get; set; }
        public string? Status { get; set; }
        public string? DataAssinaturaEletronica { get; set; }
        public string? DataLimiteAssinatura { get; set; }
        public string? DataDeclinio { get; set; }
        public string? Justificativa { get; set; }
        public string? QualificacaoAssinante { get; set; }
        public string? TipoIdentificacao { get; set; }
        public string? IdentificacaoAssinante { get; set; }
        //public bool? EnviaNotificacao { get; set; }
        public string? CargoAssinante { get; set; }
        //public string? DeclaranteArquivo { get; set; }
        public int? IdTipoIdentificacao { get; set; }
        public bool? Excluido { get; set; }
        //public string? Declarante { get; set; }
        //public string? JustificativaAnexo { get; set; }
        //public string? DataAssinatura { get; set; }
        public string? MotivoDeclinio { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? JustificativaExclusao { get; set; }
        public string? DataAssinaturaDigital { get; set; }

    }
}
