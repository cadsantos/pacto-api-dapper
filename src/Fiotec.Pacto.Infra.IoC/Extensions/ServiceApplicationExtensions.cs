using Fiotec.Pacto.Application.Services.Dicionarios;
using Fiotec.Pacto.Application.Services.Documentos;
using Fiotec.Pacto.Domain.Ports.Driving.Dicionarios;
using Fiotec.Pacto.Domain.Ports.Driving.Documentos;
using Microsoft.Extensions.DependencyInjection;

namespace Fiotec.Pacto.Infra.IoC.Extensions
{
    public static class ServiceApplicationExtensions
    {
        public static IServiceCollection AddServiceApplication(IServiceCollection service)
        {
            service.AddTransient<IDicionarioService, DicionarioService>();
            service.AddTransient<IDocumentoService, DocumentoService>();

            return service;
        }
    }
}
