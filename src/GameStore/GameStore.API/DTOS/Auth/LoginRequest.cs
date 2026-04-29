namespace GameStore.Api.DTOS.Auth;

public record LoginRequest(
    string Email,
    string Password
);

