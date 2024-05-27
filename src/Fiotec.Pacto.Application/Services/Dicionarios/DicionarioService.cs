using Fiotec.Pacto.Application.Mappers.Dicionarios;
using Fiotec.Pacto.Domain.Mappers.Dicionarios;
using Fiotec.Pacto.Domain.Models.ViewModels.Dicionarios;
using Fiotec.Pacto.Domain.Ports.Driven.Dicionarios;
using Fiotec.Pacto.Domain.Ports.Driving.Dicionarios;

namespace Fiotec.Pacto.Application.Services.Dicionarios
{
    public class DicionarioService(IDicionarioRepository dicionarioRepository) : IDicionarioService
    {
        public async Task<IEnumerable<TipoAssinaturaViewModel>> ObterTiposAssinaturas(CancellationToken cancellationToken)
        {
            var tipos_assinaturas = await dicionarioRepository.ObterTiposAssinaturas(cancellationToken);
            return tipos_assinaturas.Select(TipoAssinaturaMapper.MapFromEntity);
        }

        public async Task<IEnumerable<TipoFinalizacaoViewModel>> ObterTiposFinalizacoes(CancellationToken cancellationToken)
        {
            var tipos_finalizacoes = await dicionarioRepository.ObterTiposFinalizacoes(cancellationToken);
            return tipos_finalizacoes.Select(TipoFinalizacaoMapper.MapFromEntity);
        }

        public async Task<IEnumerable<TipoAlteracaoViewModel>> ObterTiposAlteracoes(CancellationToken cancellationToken)
        {
            var tipos_alteracoes = await dicionarioRepository.ObterTiposAlteracoes(cancellationToken);
            return tipos_alteracoes.Select(TipoAlteracaoMapper.MapFromEntity);
        }

        public async Task<IEnumerable<TipoAlteracaoViewModel>> ObterTiposAlteracoesPorTipoResponsavel(char tipoResponsavel, CancellationToken cancellationToken)
        {
            var tipos_alteracoes = await dicionarioRepository.ObterTiposAlteracoesPorTipoResponsavel(tipoResponsavel, cancellationToken);
            return tipos_alteracoes.Select(TipoAlteracaoMapper.MapFromEntity);
        }

        public async Task<IEnumerable<StatusAssinaturaViewModel>> ObterStatusAssinaturas(CancellationToken cancellationToken)
        {
            var status_assinaturas = await dicionarioRepository.ObterStatusAssianturas(cancellationToken);
            return status_assinaturas.Select(StatusAssinaturaMapper.MapFromEntity);
        }
    }
}
