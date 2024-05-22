using Fiotec.Pacto.Domain.Entities.Documentos;
using Fiotec.Pacto.Domain.Mappers.Assinaturas;
using Fiotec.Pacto.Domain.Models.ViewModels.Documentos;

namespace Fiotec.Pacto.Domain.Mappers.Documentos
{
    public static class DocumentoMapper
    {
        public static DocumentoViewModel MapFromEntity(Documento entity)
        {
            return new DocumentoViewModel
            {
                Id = entity.Id,
                Key = entity.Key.ToString(),
                Titulo = entity.Nome,
                Descricao = entity.Descricao,
                DataCadastro = entity.DataCadastro.ToString(),
                HabilitadoOrdemAssinatura = entity.HabilitadoOrdemAssinatura,
                DataPrazoFinalizacao = entity.DataPrazoFinalizacao.ToString(),
                HabilitadoNotificacao = entity.HabilitadoNotificacao,
                IdProprietario = entity.IdProprietario,
                NomeProprietario = entity.NomeProprietario,
                IdUsuario = entity.IdUsuario,
                NomeUsuario = entity.NomeUsuario,
                NomeArquivo = entity.NomeArquivo,
                IdTipoFinalizacao = entity.IdTipoFinalizacao,
                Assinaturas = entity.Assinaturas.Select(AssinaturaMapper.MapFromEntity).ToList(),
                TipoAssinatura = entity.TipoAssinatura?.Nome
            };
        }
    }
}
