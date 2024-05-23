using Fiotec.Pacto.Domain.Models.ViewModels.Services.Historicos;
using Fiotec.Pacto.Domain.Ports.Driven.Services.Historicos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Fiotec.Pacto.Infra.Services.Historicos
{
    public class HistoricoService(IConfiguration _configuration, IHttpClientFactory _httpClientFactory) : IHistoricoService
    {
        public async Task<CustomViewModel<List<HistoricoViewModel>>?> ObterHistoricoDocumento(Guid key)
        {
            var client = _httpClientFactory.CreateClient("history-services");
            var response = await client.GetAsync($"{client.BaseAddress}/api/v1/History/systemId/{_configuration["AppSettings:SistemaId"]}/instanceKey/{key}");
            if (!response.IsSuccessStatusCode || response.Content is null)
                return new CustomViewModel<List<HistoricoViewModel>>();

            return JsonConvert.DeserializeObject<CustomViewModel<List<HistoricoViewModel>>>(await response.Content.ReadAsStringAsync());
        }
    }
}
