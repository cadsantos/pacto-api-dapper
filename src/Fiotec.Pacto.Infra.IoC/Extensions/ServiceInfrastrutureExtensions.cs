using Fiotec.Pacto.Domain.Ports.Driven.Dicionarios;
using Fiotec.Pacto.Domain.Ports.Driven.Documentos;
using Fiotec.Pacto.Infra.Data.Context;
using Fiotec.Pacto.Infra.Data.Context.Abastraction;
using Fiotec.Pacto.Infra.Data.Repositories.Dicionarios;
using Fiotec.Pacto.Infra.Data.Repositories.Documentos;
using Microsoft.Extensions.DependencyInjection;

namespace Fiotec.Pacto.Infra.IoC.Extensions
{
    public static class ServiceInfrastrutureExtensions
    {
        public static IServiceCollection AddServiceInfrastruture(IServiceCollection service)
        {
            service.AddTransient<ISqlConnectionContext, SqlConnectionContext>();
            service.AddTransient<IDicionarioRepository, DicionarioRepository>();
            service.AddTransient<IDocumentoRepository, DocumentoRepository>();

            return service;
        }
    }
}
