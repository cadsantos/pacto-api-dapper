using Fiotec.Pacto.Domain.DTOs.Documentos;
using Fiotec.Pacto.Domain.Models.ViewModels.Documentos;

namespace Fiotec.Pacto.Domain.Mappers.Documentos
{
    public static class PendenteFinalizacaoManualMapper
    {
        public static DocumentoPendenteFinalizacaoManualViewModel MapFromDTO(PendenteFinalizacaoManualDTO dto)
        {
            return new DocumentoPendenteFinalizacaoManualViewModel
            {
                Id = dto.Id,
                Key = dto.Key.ToString(),
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Assinaturas = $"{dto.TotalAssinaturasRealizadas}/{dto.TotalAssinaturas}",
                Situacao = dto.Situacao,
                DataCadastro = dto.DataCadastro.ToString(),
                PrazoFinalizacao = dto.PrazoFinalizacao.ToString()
            };
        }
    }
}
