namespace Fiotec.Pacto.Domain.DTOs.SolicitacoesMudanca
{
    public record SolicitacaoMudancaPendenteDTO(
        Guid DocumentoKey,
        Guid AssinaturaKey,
        Guid SolicitacaoMudancaKey,
        string? TituloDocumento,
        string? TipoAlteracao,
        string? DescricaoDocumento,
        string? NomeAssinante,
        string? Justificativa);
}
