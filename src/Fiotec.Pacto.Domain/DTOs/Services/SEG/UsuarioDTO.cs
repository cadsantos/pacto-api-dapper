namespace Fiotec.Pacto.Domain.DTOs.Services.SEG
{
    public record UsuarioDTO(
        int IdUsuario,
        string Nome,
        string Login,
        string CPF,
        bool UsuarioAD,
        string Email,
        string Matricula);
}
