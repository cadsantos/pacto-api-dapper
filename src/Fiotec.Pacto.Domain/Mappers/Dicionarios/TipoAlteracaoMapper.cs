using Fiotec.Pacto.Domain.Entities.Dicionarios;
using Fiotec.Pacto.Domain.Models.ViewModels.Dicionarios;

namespace Fiotec.Pacto.Domain.Mappers.Dicionarios
{
    public static class TipoAlteracaoMapper
    {
        public static TipoAlteracaoViewModel MapFromEntity(TipoAlteracao entity)
        {
            return new TipoAlteracaoViewModel
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Descricao = entity.Descricao,
                Responsavel = entity.Responsavel
            };
        }
    }
}
