using Fiotec.Pacto.Domain.DTOs.Documentos;
using Fiotec.Pacto.Domain.Models.ViewModels.Documentos;

namespace Fiotec.Pacto.Domain.Mappers.Documentos
{
    public static class PendenteAssinaturaMapper
    {
        public static DocumentoPendenteAssinaturaViewModel MapFromDTO(PendenteAssinaturaDTO dto)
        {
            return new DocumentoPendenteAssinaturaViewModel
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
