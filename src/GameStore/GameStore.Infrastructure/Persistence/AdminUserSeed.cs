
using GameStore.Application.Helpers;
using GameStore.Domain.Entities;
using GameStore.Domain.ValueObjects;
using GameStore.Infrastructure.Persistence;

namespace GameStore.Infrastructure.Seed;

public static class AdminUserSeed
{
    public static async Task SeedAsync(GameStoreDbContext context)
    {
        if (context.Users.Any(u => u.Role == "Admin"))
            return;

        var admin = User.Create(
            name: "Admin",
            email: Email.Create("admin@gamestore.com"),
            passwordHash: PasswordHasher.Hash("Admin@123"),
            role: "Admin"
        );

        admin.UpdateRole("Admin");

        context.Users.Add(admin);
        await context.SaveChangesAsync();
    }
}

