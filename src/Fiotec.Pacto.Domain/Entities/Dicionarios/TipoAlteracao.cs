namespace Fiotec.Pacto.Domain.Entities.Dicionarios
{
    public sealed class TipoAlteracao
    {
        public int Id { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public char? Responsavel { get; private set; }
    }
}
