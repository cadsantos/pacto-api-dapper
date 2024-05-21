namespace Fiotec.Pacto.Domain.DTOs.Documentos
{
    public record PendenteFinalizacaoManualDTO(
        int Id,
        Guid Key,
        string Titulo,
        string Descricao,
        int TotalAssinaturasRealizadas,
        int TotalAssinaturas,
        string Situacao,
        DateTime DataCadastro,
        DateTime PrazoFinalizacao);
}
