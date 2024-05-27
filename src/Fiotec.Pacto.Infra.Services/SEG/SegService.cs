using Fiotec.Pacto.Domain.DTOs.Services.SEG;
using Fiotec.Pacto.Domain.Ports.Driven.Services.SEG;
using Fiotec.Pacto.Infra.Utils.Resources;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Fiotec.Pacto.Infra.Services.SEG
{
    public class SegService(IHttpClientFactory httpClientFactory) : ISegService
    {
        public async Task<UsuarioDTO?> GetUsuarioPorIdAsync(int id)
        {
            var client = httpClientFactory.CreateClient(ServiceResource.SegServices);
            var response = await client.GetAsync($"{client.BaseAddress}/api/usuarios/{id}");
            if (!response.IsSuccessStatusCode || response.Content is null)
                return null;

            return JsonConvert.DeserializeObject<UsuarioDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ClaimsPrincipal?> AuthenticateJwtToken(string token)
        {
            using var client = httpClientFactory.CreateClient(ServiceResource.SegServices);
            var json = JsonConvert.SerializeObject(new { Token = token });

            var response = await client.PostAsync($"{client.BaseAddress}/v2/login/verify", new StringContent(json, Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode || response.Content is null)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            using MemoryStream stream = new MemoryStream(Convert.FromBase64String(content.Replace("\"", "")));
            using BinaryReader br = new BinaryReader(stream);
            return new ClaimsPrincipal(br);
        }

        public async Task<LoginDTO?> Login(string login, string senha)
        {
            using var client = httpClientFactory.CreateClient(ServiceResource.SegServices);
            var json = JsonConvert.SerializeObject(new { Login = login, Senha = senha });
            var response = await client.PostAsync($"{client.BaseAddress}/login/auth", new StringContent(json, Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode || response.Content is null)
                return null;
            return JsonConvert.DeserializeObject<LoginDTO?>(await response.Content.ReadAsStringAsync());
        }
    }
}
