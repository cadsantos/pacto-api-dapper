using Fiotec.Pacto.Domain.Models.ViewModels.Services.Historicos;

namespace Fiotec.Pacto.Domain.Ports.Driven.Services.Historicos
{
    public interface IHistoricoService
    {
        Task<CustomViewModel<List<HistoricoViewModel>>?> ObterHistoricoDocumento(Guid key);
    }
}
