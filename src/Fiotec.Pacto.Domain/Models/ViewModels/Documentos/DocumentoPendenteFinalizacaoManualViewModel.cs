namespace Fiotec.Pacto.Domain.Models.ViewModels.Documentos
{
    public class DocumentoPendenteFinalizacaoManualViewModel
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Assinaturas { get; set; }
        public string? Situacao { get; set; }
        public string? DataCadastro { get; set; }
        public string? PrazoFinalizacao { get; set; }
    }
}
