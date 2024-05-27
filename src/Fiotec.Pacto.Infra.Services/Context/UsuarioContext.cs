using Fiotec.Pacto.Domain.Ports.Driven.Context;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Pacto.Infra.Services.Context
{
    public sealed class UsuarioContext(IHttpContextAccessor httpContextAccessor) : IUsuarioContext
    {
        public string? UsuarioId => httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
        public bool Autenticado => httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
