namespace GameStore.Api.DTOS.Users;

public record LoginRequest(
    string Email,
    string Password
);

