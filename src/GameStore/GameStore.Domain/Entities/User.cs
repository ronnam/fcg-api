using System;
using System.Linq;

namespace GameStore.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    protected User() { }

    private User(string name, string email, string password)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
    }

    public static User Create(
        string name,
        string email,
        string password)
    {
        Validate(name, email, password);

        return new User(name, email, password);
    }

    private static void Validate(string name, string email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.");

        if (!email.Contains('@'))
            throw new ArgumentException("Invalid email.");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Invalid Password.");
    }
}

