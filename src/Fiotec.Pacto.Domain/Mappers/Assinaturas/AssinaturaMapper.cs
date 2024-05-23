using Fiotec.Pacto.Domain.Entities.Assinaturas;
using Fiotec.Pacto.Domain.Models.ViewModels.Assinaturas;

namespace Fiotec.Pacto.Domain.Mappers.Assinaturas
{
    public static class AssinaturaMapper
    {
        public static AssinaturaViewModel MapFromEntity(Assinatura entity)
        {
            return new AssinaturaViewModel
            {
                Id = entity.Id,
                IdDocumento = entity.IdDocumento,
                IdStatus = entity.IdStatus,
                Status = entity.StatusAssinatura?.Nome,
                IdAssinante = entity.IdAssinante,
                IdTipoIdentificacao = entity.IdTipoIdentificacao,
                TipoIdentificacao = entity.TipoIdentificacao?.Descricao,
                Excluido = entity.Excluido,
                Ordem = entity.Ordem,
                Key = entity.Key,
                MotivoDeclinio = entity.MotivoDeclinio,
                CargoAssinante = entity.CargoAssinante,
                NumeroDocumento = entity.NumeroDocumento,
                NomeAssinante = entity.NomeAssinante,
                JustificativaExclusao = entity.JustificativaExclusao,
                IdentificacaoAssinante = entity.IdentificacaoAssinante,
                QualificacaoAssinante = entity.QualificacaoAssinante,
                DataLimiteAssinatura = entity.DataLimiteAssinatura?.ToString(),
                DataAssinaturaEletronica = entity.DataAssinaturaEletronica?.ToString(),
                DataAssinaturaDigital = entity.DataAssinaturaDigital?.ToString(),
                DataDeclinio = entity.DataDeclinio?.ToString(),
                Justificativa = entity.Justificativa
            };
        }
    }
}
