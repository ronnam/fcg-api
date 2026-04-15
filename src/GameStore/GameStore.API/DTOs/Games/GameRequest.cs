namespace GameStore.API.DTOs.Games;
public class GameRequest    
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
}
