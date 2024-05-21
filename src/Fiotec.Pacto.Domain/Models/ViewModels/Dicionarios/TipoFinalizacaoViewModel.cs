using System.Text.Json.Serialization;

namespace Fiotec.Pacto.Domain.Models.ViewModels.Dicionarios
{
    public class TipoFinalizacaoViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        [JsonPropertyName("data_inclusao")]
        public string? DataInclusao { get; set; }
        public bool Ativo { get; set; }
    }
}
