using Fiotec.Pacto.Domain.Entities.Assinaturas;
using Fiotec.Pacto.Domain.Entities.Dicionarios;

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
    }
}
