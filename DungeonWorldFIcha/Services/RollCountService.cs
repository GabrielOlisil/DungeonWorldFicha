using System.Collections;

namespace DungeonWorldFIcha.Services;

public class RollCountService
{
    private Queue<string> rolagens = new Queue<string>();



    public void AddRoll(string roll)
    {
        rolagens.Enqueue(roll);

        if (rolagens.Count > 5)
        {
            rolagens.Dequeue();
        }
    }


    public bool IsQueueNotEmpty()
    {
        return rolagens.Count > 0;
    }


    public string RenderRoll()
    {
        return rolagens.Aggregate(string.Empty, (current, rolagem) => current + $"{rolagem}\n");
    }
    
}