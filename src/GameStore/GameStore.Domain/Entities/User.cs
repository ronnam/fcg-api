using System;
using GameStore.Domain.ValueObjects;

namespace GameStore.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }

    protected User() { }

    private User(string name, Email email, string password, string role)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public static User Create(
        string name,
        Email email,
        string password,
        string role = "User")

    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password is required.");

        if (role != "User" && role != "Admin")
            throw new ArgumentException("Invalid role.");

        return new User(name, email, password, role);
    }


}

