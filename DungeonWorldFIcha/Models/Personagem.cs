using System.Security.Cryptography.X509Certificates;

namespace DungeonWorldFIcha.Models;

public class Personagem
{
    public Guid PersonagemId { get; set; }
    public string Nome { get; set; }
    public int Pv { get; set; }
    public int Armadura { get; set; }
    public int DadoDano { get; set; }
    public int Nivel { get; set; }
    public string? Equipamentos { get; set; }
    public List<Movimento>? Movimentos { get; set; }
    public string Descricao { get; set; }
    public Habilidade Habilidade { get; set; }

    public override string ToString()
    {
        return $"""
               Id = {PersonagemId.ToString()}
               Nome = {Nome} ?? ""
               Pv = {Pv.ToString()}
               Armadura = {Armadura.ToString()}
               DadoDano = {DadoDano.ToString()}
               Nivel = {Nivel.ToString()}
               Descricao = {Descricao}
               """;
    }
}