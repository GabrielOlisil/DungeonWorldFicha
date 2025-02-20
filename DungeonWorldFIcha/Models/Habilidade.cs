using System.ComponentModel.DataAnnotations;

namespace DungeonWorldFIcha.Models;

public class Habilidade
{
    public int Id { get; set; }
    [Range(1, 18)] public int Forca { get; set; }
    [Range(1, 18)] public int Destreza { get; set; }
    [Range(1, 18)] public int Constituicao { get; set; }
    [Range(1, 18)] public int Inteligencia { get; set; }
    [Range(1, 18)] public int Sabedoria { get; set; }
    [Range(1, 18)] public int Carisma { get; set; }
}