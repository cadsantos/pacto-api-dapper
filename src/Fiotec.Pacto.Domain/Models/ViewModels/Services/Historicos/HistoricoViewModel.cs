namespace Fiotec.Pacto.Domain.Models.ViewModels.Services.Historicos
{
    public class HistoricoViewModel
    {
        public int? SystemId { get; set; }
        public string? SystemName { get; set; }
        public string? SourceTableName { get; set; }
        public int? ProcessId { get; set; }
        public string? ProcessDetail { get; set; }
        public int? InstanceProcessId { get; set; }
        public string? InstanceProcessName { get; set; }
        public string? InstanceKey { get; set; }
        public int? UserLoginId { get; set; }
        public string? UserLoginName { get; set; }
        public string? LogStatusId { get; set; }
        public int? SystemStatusId { get; set; }
        public string? SystemStatusDetail { get; set; }
        public DateTime? DateTimeProcess { get; set; }
        public DateTime? DateTimeCreate { get; set; }
        public string? Obs { get; set; }
        public string? Comment { get; set; }
        public string? Justification { get; set; }
        public string? SupplementaryJustification { get; set; }
        public string? KeyRollback { get; set; }
        public string? HashPrevious { get; set; }
        public string? Hash { get; set; }
        public List<ListaHistoricoExtensaoInputModel>? CreateListHistoryExtensionRequest { get; set; }
    }
}
