using Fiotec.Pacto.Domain.Entities.Dicionarios;
using Fiotec.Pacto.Domain.Models.ViewModels.Dicionarios;

namespace Fiotec.Pacto.Domain.Mappers.Dicionarios
{
    public static class TipoFinalizacaoMapper
    {
        public static TipoFinalizacaoViewModel MapFromEntity(TipoFinalizacao entity)
        {
            return new TipoFinalizacaoViewModel
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Descricao = entity.Descricao,
                DataInclusao = entity.DataInclusao.ToString(),
                Ativo = entity.Ativo
            };
        }
    }
}
