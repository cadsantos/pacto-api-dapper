using Fiotec.Pacto.Domain.DTOs.Documentos;
using Fiotec.Pacto.Domain.Models.ViewModels.Documentos;

namespace Fiotec.Pacto.Domain.Mappers.Documentos
{
    public static class DocumentoAdministracaoMapper
    {
        public static DocumentoAdministracaoViewModel MapFromDTO(DocumentoAdministracaoDTO dto)
        {
            return new DocumentoAdministracaoViewModel
            {
                Id = dto.Id,
                Key = dto.Key.ToString(),
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Assinaturas = $"{dto.TotalAssinaturasRealizadas}/{dto.TotalAssinaturas}",
                TipoFinalizacao = dto.TipoFinalizacao,
                DataCadastro = dto.DataCadastro.ToString(),
                PrazoFinalizacao = dto.PrazoFinalizacao.ToString()
            };
        }
    }
}
