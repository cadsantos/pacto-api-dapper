using Fiotec.Pacto.Domain.Entities.Dicionarios;
using Fiotec.Pacto.Domain.Models.ViewModels.Dicionarios;

namespace Fiotec.Pacto.Application.Mappers.Dicionarios
{
    public static class TipoAssinaturaMapper
    {
        public static TipoAssinaturaViewModel MapFromEntity(TipoAssinatura entity)
        {
            return new TipoAssinaturaViewModel
            {
                Id = entity.Id,
                Nome = entity.Nome,
                DataInclusao = entity.DataInclusao.ToString(),
                Ativo = entity.Ativo
            };
        }
    }
}
