namespace Fiotec.Pacto.Domain.DTOs.Documentos
{
    public record DocumentoAdministracaoDTO(
        int Id,
        Guid Key,
        string Titulo,
        string Descricao,
        int TotalAssinaturasRealizadas,
        int TotalAssinaturas,
        string TipoFinalizacao,
        DateTime DataCadastro,
        DateTime PrazoFinalizacao);
}
