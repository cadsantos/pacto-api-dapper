namespace Fiotec.Pacto.Domain.DTOs.Documentos
{
    public record DocumentoDTO(
        int Id,
        Guid Key,
        string Titulo,
        string Descricao,
        DateTime DataCadastro,
        bool HabilitadoOrdemAssinatura,
        DateTime DataPrazoFinalizacao,
        bool HabilitadoNotificacao,
        int IdProprietario,
        string NomeProprietario,
        string NomeArquivo,
        int IdTipoFinalizacao
        );
}
