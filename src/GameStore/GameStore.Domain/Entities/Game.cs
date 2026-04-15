using System;

namespace GameStore.Domain.Entities;

public class Game
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public decimal Price { get; private set; }

    protected Game() { }

    private Game(string title, decimal price)
    {
        Id = Guid.NewGuid();
        Title = title;
        Price = price;
    }

    public static Game Create(string title, decimal price)
    {
        Validate(title, price);

        return new Game(title, price);
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("Price must be greater than 0.");

        Price = newPrice;
    }

    private static void Validate(string title, decimal price)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.");

        if (price <= 0)
            throw new ArgumentException("Invalid price.");
    }
}

