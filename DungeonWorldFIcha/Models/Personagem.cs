using System.ComponentModel.DataAnnotations;

namespace DungeonWorldFIcha.Models;

public class Personagem
{
    public int PersonagemId { get; set; }

    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "Campo 0brigatório.")]
    [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo 0brigatório.")]
    public int Pv { get; set; }

    [Required(ErrorMessage = "Campo 0brigatório.")]
    public int Armadura { get; set; }

    [Required(ErrorMessage = "Campo 0brigatório.")]
    public int DadoDano { get; set; }

    [Required(ErrorMessage = "Campo 0brigatório.")]
    public int Nivel { get; set; }

    [StringLength(50, ErrorMessage = "A classe não pode ter mais de 50 caracteres.")]
    [Required(ErrorMessage = "Campo 0brigatório.")]

    public string Classe { get; set; }

    public string? DescricaoUm { get; set; }

    public string? Equipamento { get; set; }

    [Display(Name = "Descrição 2")]
    public string? DescricaoDois { get; set; }
    
    public Habilidade Habilidade { get; set; }

    public override string ToString()
    {
        return $"""
               Id = {PersonagemId.ToString()}
               Nome = {Nome ?? ""}
               Pv = {Pv.ToString()}
               Armadura = {Armadura.ToString()}
               DadoDano = {DadoDano.ToString()}
               Nivel = {Nivel.ToString()}
               """;
    }
}