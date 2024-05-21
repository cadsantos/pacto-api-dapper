using System.Text.Json.Serialization;

namespace Fiotec.Pacto.Domain.Models.ViewModels.Dicionarios
{
    public class TipoAssinaturaViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        [JsonPropertyName("data_inclusao")]
        public string? DataInclusao { get; set; }
        public bool? Ativo { get; set; }
    }
}
