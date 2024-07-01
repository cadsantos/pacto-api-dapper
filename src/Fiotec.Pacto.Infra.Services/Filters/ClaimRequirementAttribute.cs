using Fiotec.Pacto.Infra.Utils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Pacto.Infra.Services.Filters
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute() : base(typeof(ClaimRequirementFilter))
        {
            
        }
    }

    public class ClaimRequirementFilter(
        IHttpClientFactory httpClientFactory) : IAuthorizationFilter
    {


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers["Authorization"].Count == 0)
            {
                context.Result = new ForbidResult();
                return;
            }

            var jwtToken = context.HttpContext.Request.Headers["Authorization"][0].Replace("Bearer ", "");

            var principal = AuthenticateJwtToken(jwtToken);

            if (principal == null)
            {
                context.Result = new ForbidResult();
                return;
            }

            context.HttpContext.User = principal.Result;

            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new ForbidResult();
                return;
            }
        }

        internal async Task<ClaimsPrincipal> AuthenticateJwtToken(string token)
        {
            var verify = new
            {
                Token = token
            };

            var json = JsonConvert.SerializeObject(verify);
            var client = httpClientFactory.CreateClient(ServiceResource.HistoryServices);
            var response = await client.PostAsync($"{client.BaseAddress}/v2/login/verify/", new StringContent(json, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode && response.Content is not null)
            {
                using MemoryStream stream = new MemoryStream(Convert.FromBase64String(await response.Content.ReadAsStringAsync()));
                using BinaryReader br = new BinaryReader(stream);
                return new ClaimsPrincipal(br);
            }
            return null;
        }
    }
}
