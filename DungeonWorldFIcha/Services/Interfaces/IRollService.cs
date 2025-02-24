namespace DungeonWorldFIcha.Services.Interfaces;

public interface IRollService
{
    void AddRoll(string element);

    bool IsQueueNotEmpty();
    string RenderRoll();


}