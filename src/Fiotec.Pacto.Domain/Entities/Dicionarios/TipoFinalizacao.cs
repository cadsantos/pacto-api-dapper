namespace Fiotec.Pacto.Domain.Entities.Dicionarios
{
    public sealed class TipoFinalizacao
    {
        public int Id { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public bool Ativo { get; private set; }
    }

}
