namespace Fiotec.Pacto.Domain.DTOs.SolicitacoesMudanca
{
    public record SolicitacaoMudancaDetalhesDTO(
        Guid Key,
        Guid DocumentoKey,
        Guid AssinaturaKey,
        int IdTipoAlteracao,
        string? NomeAlteracao,
        string? StatusMudancaDescricao,
        string? SolicitacaoMudancaJustificativa,
        DateTime AssinaturaDataPrazoAssinatura,
        DateTime? SolicitacaoMudancaNovaDataPrazoAssinatura,
        int AssinaturaIdAssinante,
        int? SolicitacaoMudancaNovoIdAssinante,
        string? AssinaturaQualificacao,
        string? SolicitacaoMudancaNovaQualificacao,
        string? AssinaturaIdentificacao,
        string? SolicitacaoMudancaNovaAssinaturaIdentificacao,
        short? IdTipoIdentificacao,
        string? TipoIdentificacao,
        string? SolicitacaoMudancaNovaIdentificacao);

}
