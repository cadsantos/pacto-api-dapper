namespace Fiotec.Pacto.Domain.Models.ViewModels.Documentos
{
    public class HistoricoDocumentoViewModel
    {
        public int UsuarioId { get; set; }
        public Guid KeyDocumento { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Status { get; set; }
        public string? DataInclusao { get; set; }
        public string? Descricao { get; set; }
        public string? ProcessoDescricao { get; set; }
        public string? DescricaoComplementar { get; set; }
        public string? Observacao { get; set; }
    }
}
