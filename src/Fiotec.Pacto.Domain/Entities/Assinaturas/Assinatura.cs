using Fiotec.Pacto.Domain.Entities.Dicionarios;
using Fiotec.Pacto.Domain.Entities.Documentos;

namespace Fiotec.Pacto.Domain.Entities.Assinaturas
{
    public sealed class Assinatura
    {
        public int Id { get; private set; }
        public int IdDocumento { get; private set; }
        public int IdStatus { get; private set; }
        public int? IdAssinante { get; private set; }
        public int? IdTipoIdentificacao { get; private set; }
        public bool? Excluido { get; private set; }
        public int? Ordem { get; private set; }
        public Guid Key { get; private set; }
        public string? MotivoDeclinio { get; private set; }
        public string? CargoAssinante { get; private set; }
        public string? NumeroDocumento { get; private set; }
        public string? NomeAssinante { get; private set; }
        public string? JustificativaExclusao { get; private set; }
        public string? IdentificacaoAssinante { get; private set; }
        public string? QualificacaoAssinante { get; private set; }
        public DateTime? DataLimiteAssinatura { get; private set; }
        public DateTime? DataAssinaturaEletronica { get; private set; }
        public DateTime? DataAssinaturaDigital { get; private set; }
        public DateTime? DataDeclinioAssinatura { get; private set; }
        public string? Justificativa { get; private set; }

        public Documento? Documento { get; private set; }
        //public Tipoi TipoIdentificacao { get; set; }
        public StatusAssinatura? StatusAssinatura { get; set; }
    }
}
