using Fiotec.Pacto.Domain.DTOs.Services.SEG;
using System.Security.Claims;

namespace Fiotec.Pacto.Domain.Ports.Driven.Services.SEG
{
    public interface ISegService
    {
        Task<UsuarioDTO?> GetUsuarioPorIdAsync(int id);
        Task<LoginDTO?> Login(string login, string senha);
        Task<ClaimsPrincipal?> AuthenticateJwtToken(string token);
    }
}
