using System.Collections;

namespace DungeonWorldFIcha.Services;

public class RollCountService
{
    private Queue<string> _rolagens = new Queue<string>();



    public void AddRoll(string roll)
    {
        _rolagens.Enqueue(roll);

        if (_rolagens.Count > 5)
        {
            _rolagens.Dequeue();
        }
    }


    public bool IsQueueNotEmpty()
    {
        return _rolagens.Count > 0;
    }


    public string RenderRoll()
    {
        var rolagens = string.Empty;

        foreach (var rolagem in _rolagens)
        {
            
            rolagens += rolagem + ";";
        }
        
        if (!string.IsNullOrEmpty(rolagens)) // Evita erro em string vazia
        {
            rolagens = rolagens.Substring(0, rolagens.Length - 1);
        }

        return rolagens;
    }
    
}