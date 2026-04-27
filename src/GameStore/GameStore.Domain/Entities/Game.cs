using System;

namespace GameStore.Domain.Entities;

public class Game
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Category { get; private set; }

    protected Game() { }

    private Game(string title, string category)
    {
        Id = Guid.NewGuid();
        Title = title;
        Category = category;
    }

    public static Game Create(string title, string category)
    {
        Validate(title, category);

        return new Game(title, category);
    }

    private static void Validate(string title, string category)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.");

        if (string.IsNullOrWhiteSpace(category))
            throw new ArgumentException("Category is required.");

    }
}

