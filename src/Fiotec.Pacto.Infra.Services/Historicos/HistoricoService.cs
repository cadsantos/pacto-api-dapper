using Fiotec.Pacto.Domain.Models.ViewModels.Services.Historicos;
using Fiotec.Pacto.Domain.Ports.Driven.Services.Historicos;
using Fiotec.Pacto.Infra.Utils.Resources;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Fiotec.Pacto.Infra.Services.Historicos
{
    public class HistoricoService(IConfiguration configuration, IHttpClientFactory httpClientFactory) : IHistoricoService
    {
        public async Task<CustomViewModel<List<HistoricoViewModel>>?> ObterHistoricoDocumento(Guid key)
        {
            var client = httpClientFactory.CreateClient(ServiceResource.HistoryServices);
            var response = await client.GetAsync($"{client.BaseAddress}/api/v1/History/systemId/{configuration["AppSettings:SistemaId"]}/instanceKey/{key}");
            if (!response.IsSuccessStatusCode || response.Content is null)
                return new CustomViewModel<List<HistoricoViewModel>>();

            return JsonConvert.DeserializeObject<CustomViewModel<List<HistoricoViewModel>>>(await response.Content.ReadAsStringAsync());
        }
    }
}
