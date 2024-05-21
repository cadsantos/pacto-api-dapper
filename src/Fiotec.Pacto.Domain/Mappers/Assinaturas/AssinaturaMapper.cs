using Fiotec.Pacto.Domain.Entities.Assinaturas;
using Fiotec.Pacto.Domain.Models.ViewModels.Assinaturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Pacto.Domain.Mappers.Assinaturas
{
    public static class AssinaturaMapper
    {
        public static AssinaturaViewModel MapFromEntity(Assinatura entity)
        {
            return new AssinaturaViewModel
            {
                Id = entity.Id
            };
        }
    }
}
