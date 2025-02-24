using System.Text.Json.Serialization;

namespace DungeonWorldFIcha.Models.Serialization;

public class PersonagemSerializer : Personagem
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public int? PersonagemId { get; set; } = null;

}