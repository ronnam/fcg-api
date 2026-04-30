namespace GameStore.API.DTOs.Games;
public class GameRequest    
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Category { get; set; }
}
