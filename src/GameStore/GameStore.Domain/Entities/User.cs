using System;
using System.Data;
using System.Linq;

namespace GameStore.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }

    protected User() { }

    private User(string name, string email, string password, string role)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public static User Create(
        string name,
        string email,
        string password,
        string role = "User")
    {
        Validate(name, email, password, role);

        return new User(name, email, password, role);
    }

    private static void Validate(string name, string email, string passwordHash, string role)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.");

        if (!email.Contains('@'))
            throw new ArgumentException("Invalid email.");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Invalid Password.");

        if (role != "User" && role != "Admin")
            throw new ArgumentException("Invalid role.");

    }
}

