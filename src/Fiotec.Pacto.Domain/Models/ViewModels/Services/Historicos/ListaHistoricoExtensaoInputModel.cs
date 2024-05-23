namespace Fiotec.Pacto.Domain.Models.ViewModels.Services.Historicos
{
    public class ListaHistoricoExtensaoInputModel
    {
        public bool? Deleted { get; set; }
        public DateTime? DateTimeDeleted { get; set; }
        public string? TypeExtensionId { get; set; }
        public string? Value { get; set; }
    }
}
