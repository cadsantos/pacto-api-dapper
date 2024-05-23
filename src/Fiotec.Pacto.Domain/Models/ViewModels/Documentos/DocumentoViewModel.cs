using Fiotec.Pacto.Domain.Models.ViewModels.Assinaturas;

namespace Fiotec.Pacto.Domain.Models.ViewModels.Documentos
{
    public class DocumentoViewModel
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? DataCadastro { get; set; }
        public string? TipoAssinatura { get; set; }
        public bool HabilitadoOrdemAssinatura { get; set; }
        public string? Status { get; set; }
        public string? DataPrazoFinalizacao { get; set; }
        public bool? HabilitadoNotificacao { get; set; }
        public int? IdUsuario { get; set; }
        public string? NomeUsuario { get; set; }
        public int? IdProprietario { get; set; }
        public string? NomeProprietario { get; set; }
        public string? NomeArquivo { get; set; }
        public int? IdTipoFinalizacao { get; set; }
        public string? TipoFinalizacao { get; set; }
        public int? IdStatus { get; set; }
        public bool HabilitaBotaoAssinar { get; set; } = false;
        public bool HabilitaBotaoDeclinar { get; set; }
        public bool HabilitaBotaoExcluir { get; set; }
        public bool HabilitaBotaoUploadAssinatura { get; set; }
        public bool HabilitaBotaoSolicitarMudanca { get; set; }
        public bool HabilitaBotaoDownloadAssinado { get; set; }
        public bool HabilitaBotaoFinalizaoManual { get; set; }
        public bool HabilitaInserirAssinante { get; set; }
        public bool HabilitaEditarAssinante { get; set; }
        public bool HabilitaSubstituirAssinante { get; set; }
        public bool HabilitaDelegarAssinante { get; set; }
        public bool HabilitaAvocarAssinatura { get; set; }
        public bool HabilitaExcluirAssinante { get; set; }
        public bool HabilitaSubstituirAnexo { get; set; }
        public bool HabilitaExcluirDocumento { get; set; }
        public bool HabilitaAnexosComplementares { get; set; }
        public List<AssinaturaViewModel> Assinaturas { get; set; } = new();
        public List<HistoricoDocumentoViewModel> Historicos { get; set; } = new();
    }
}
