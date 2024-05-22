using Fiotec.Pacto.Domain.Models.ViewModels.Assinaturas;
using System.Text.Json.Serialization;

namespace Fiotec.Pacto.Domain.Models.ViewModels.Documentos
{
    public class DocumentoViewModel
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        [JsonPropertyName("data_inclusao")]
        public string? DataCadastro { get; set; }
        public bool HabilitadoOrdemAssinatura { get; set; }
        [JsonPropertyName("data_prazo_finalizacao")]
        public string? DataPrazoFinalizacao { get; set; }
        public bool? HabilitadoNotificacao { get; set; }
        public int? IdProprietario { get; set; }
        public string? NomeProprietario { get; set; }
        public int? IdUsuario { get; set; }
        public string? NomeUsuario { get; set; }
        public string? NomeArquivo { get; set; }
        public int? IdTipoFinalizacao { get; set; }
        [JsonPropertyName("tipo_assinatura")]
        public string? TipoAssinatura { get; set; }
        public List<AssinaturaViewModel> Assinaturas { get; set; } = new();
    }
}
