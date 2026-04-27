using GameStore.Domain.Entities;

namespace GameStore.API.DTOs.Games;

public class GameResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }

    public static GameResponse FromEntity(Game game)
    {
        return new GameResponse
        {
            Id = game.Id,
            Title = game.Title,
            Category = game.Category
        };
    }
}
