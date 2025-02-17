namespace DungeonWorldFIcha.Models;

public class Movimento
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public List<string>? Situacoes { get; set; }
}