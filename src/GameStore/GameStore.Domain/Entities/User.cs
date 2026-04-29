using GameStore.Domain.ValueObjects;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace GameStore.Domain.Entities;

public class User
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required Email Email { get; init; }
    public required string PasswordHash { get; init; }
    public required string Role { get; init; }

    private User() { }

    [SetsRequiredMembers]
    private User(string name, Email email, string passwordhash, string role)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PasswordHash = passwordhash;
        Role = role;
    }

    public static User Create(
        string name,
        Email email,
        string passwordhash,
        string role = "User")

    {
        Validate(name, email, passwordhash, role);
        return new User(name, email, passwordhash, role);
    }
    private static void Validate(
        string name,
        Email email,
        string passwordHash,
        string role)
    {

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password is required.");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Invalid Password.");

        if (role != "User" && role != "Admin")
            throw new ArgumentException("Invalid role.");
    }
}
