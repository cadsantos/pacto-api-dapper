using Fiotec.Pacto.Domain.Ports.Driven.Dicionarios;
using Fiotec.Pacto.Domain.Ports.Driven.Documentos;
using Fiotec.Pacto.Domain.Ports.Driven.Services.Arquivos;
using Fiotec.Pacto.Domain.Ports.Driven.Services.Azure.BlobStorage;
using Fiotec.Pacto.Domain.Ports.Driven.Services.Historicos;
using Fiotec.Pacto.Domain.Ports.Driven.SolicitacoesMudanca;
using Fiotec.Pacto.Infra.Data.Context;
using Fiotec.Pacto.Infra.Data.Context.Abastraction;
using Fiotec.Pacto.Infra.Data.Repositories.Dicionarios;
using Fiotec.Pacto.Infra.Data.Repositories.Documentos;
using Fiotec.Pacto.Infra.Data.Repositories.SolicitacoesMudanca;
using Fiotec.Pacto.Infra.Services.Arquivos;
using Fiotec.Pacto.Infra.Services.Azure.BlobStorage;
using Fiotec.Pacto.Infra.Services.Historicos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace Fiotec.Pacto.Infra.IoC.Extensions
{
    public static class ServiceInfrastrutureExtensions
    {
        public static IServiceCollection AddServiceInfrastruture(IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<ISqlConnectionContext, SqlConnectionContext>();
            service.AddTransient<IDicionarioRepository, DicionarioRepository>();
            service.AddTransient<IDocumentoRepository, DocumentoRepository>();
            service.AddTransient<ISolicitacaoMudancaRepository, SolicitacaoMudancaRepository>();

            service.AddTransient<IHistoricoService, HistoricoService>();
            service.AddTransient<IArquivoService, ArquivoService>();
            service.AddTransient<IAzureBlobStorageService, AzureBlobStorageService>();

            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            //service.AddHttpClient("bry-service", options =>
            //{
            //    options.BaseAddress = new Uri(configuration["Services:BRy:UrlApi"]);
            //}).AddPolicyHandler(retryPolicy);

            //service.AddHttpClient("seg-services", options =>
            //{
            //    options.BaseAddress = new Uri(configuration["Services:Seg:UrlApi"]);
            //}).AddPolicyHandler(retryPolicy);

            service.AddHttpClient("history-services", options =>
            {
                options.BaseAddress = new Uri(configuration["Services:History:UrlApi"]);
            }).AddPolicyHandler(retryPolicy);

            //service.AddHttpClient("bry-hub-service", options =>
            //{
            //    options.BaseAddress = new Uri(configuration["Services:BRy:UrlHub"]);
            //}).AddPolicyHandler(retryPolicy);

            return service;
        }
    }
}
