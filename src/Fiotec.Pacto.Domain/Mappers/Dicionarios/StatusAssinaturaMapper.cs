using Fiotec.Pacto.Domain.Entities.Dicionarios;
using Fiotec.Pacto.Domain.Models.ViewModels.Dicionarios;

namespace Fiotec.Pacto.Domain.Mappers.Dicionarios
{
    public static class StatusAssinaturaMapper
    {
        public static StatusAssinaturaViewModel MapFromEntity(StatusAssinatura entity)
        {
            return new StatusAssinaturaViewModel
            {
                Id = entity.Id,
                Nome = entity.Nome
            };
        }
    }
}
