using Fiotec.Pacto.Domain.Entities.Assinaturas;
using Fiotec.Pacto.Domain.Entities.Dicionarios;
using Fiotec.Pacto.Domain.Enums;

namespace Fiotec.Pacto.Domain.Entities.Documentos
{
    public sealed class Documento
    {
        public int Id { get; private set; }
        public Guid Key { get; private set; }
        public int IdSistemaOrigem { get; private set; }
        public int IdTipoAssinatura { get; private set; }
        public int? IdTipoFinalizacao { get; private set; }
        public int? IdStatus { get; private set; }
        public int? IdUsuario { get; private set; }
        public int? IdProprietario { get; private set; }
        public string? IdIdentificadorCarimboTempo { get; private set; }
        public string? HashCarimboTempo { get; private set; }
        public bool HabilitadoRodape { get; private set; }
        public bool HabilitadoOrdemAssinatura { get; private set; }
        public bool? HabilitadoNotificacao { get; private set; }
        public string? NomeUsuario { get; private set; }
        public string? NomeProprietario { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public string? NomeArquivo { get; private set; }
        public string? InformacoesAdicionais { get; private set; }
        public string? MotivoExclusao { get; private set; }
        public DateTime? DataPrazoFinalizacao { get; private set; }
        public DateTime? DataCadastro { get; private set; }
        public DateTime? DataExclusao { get; private set; }

        public ICollection<Assinatura> Assinaturas { get; private set; } = new HashSet<Assinatura>();
        public TipoAssinatura? TipoAssinatura { get; set; }
        public TipoFinalizacao? TipoFinalizacao { get; set; }
        public StatusAssinatura? StatusDocumento { get; set; }

        public bool IsProprietario(int id)
        {
            return IdUsuario == id;
        }

        public bool IsProprietarioAssinante(int id)
        {
            return IdUsuario == id && Assinaturas.Any(a => a.IdAssinante == id);
        }

        public bool IsNenhumaAssinaturaRealizada()
        {
            return Assinaturas.All(a => a.IdStatus == (int)EStatusAssinatura.NaoAssinado);
        }

        public bool IsAssinadoParcialmente()
        {
            return Assinaturas.Any(a => a.IdStatus == (int)EStatusAssinatura.Assinado);
        }

        public bool IsAssinadoTotalmente()
        {
            return Assinaturas.All(a => a.IdStatus == (int)EStatusAssinatura.Assinado);
        }

        public bool IsFinalizado()
        {
            return IdStatus == (int)EStatusAssinatura.Assinado && Assinaturas.All(a => a.IdStatus == (int)EStatusAssinatura.Assinado);
        }

        public bool IsDeclinadoExpirado()
        {
            int?[] statusDeclinadoExpirado = { (int)EStatusAssinatura.Cancelado, (int)EStatusAssinatura.Expirado };
            return statusDeclinadoExpirado.Contains(IdStatus) && Assinaturas.Any(a => statusDeclinadoExpirado.Contains(a.IdStatus));
        }

        public string ObtemNomeArquivoOriginal()
        {
            return $"{Nome} - Original.pdf";
        }

        public string ObtemNomeArquivoAssinado()
        {
            return $"{Nome} - Assinado.pdf";
        }

        public string ObtemNomeArquivoOriginalPorKey()
        {
            return $"{Key}_original.pdf";
        }

        public string ObtemNomeArquivoAssinadoPorKey()
        {
            return $"{Key}_assinado.pdf";
        }

        public string ObtemCaminhoArquivo(bool isBlob = false)
        {
            if (DataCadastro is null) return string.Empty;
            if (isBlob) return $"{DataCadastro.Value.Year}\\{DataCadastro.Value.Month}\\{DataCadastro.Value.Day}";
            return $"\\{DataCadastro.Value.Year}\\{DataCadastro.Value.Month}\\{DataCadastro.Value.Day}";
        }
    }
}
