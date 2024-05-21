using Fiotec.Pacto.Domain.Models.ViewModels.Assinaturas;

namespace Fiotec.Pacto.Domain.Models.ViewModels.Documentos
{
    public class DocumentoViewModel
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? DataCadastro { get; set; }
        public bool HabilitadoOrdemAssinatura { get; set; }
        public string? DataPrazoFinalizacao { get; set; }
        public bool? HabilitadoNotificacao { get; set; }
        public int? IdProprietario { get; set; }
        public string? NomeProprietario { get; set; }
        public string? NomeArquivo { get; set; }
        public int? IdTipoFinalizacao { get; set; }
        public List<AssinaturaViewModel> Assinaturas { get; set; } = new();
    }
}
