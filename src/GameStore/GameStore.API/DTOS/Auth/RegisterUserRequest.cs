namespace GameStore.Api.DTOS.Auth
{
    public record RegisterUserRequest(
        string Name,
        string Email,
        string Password
    );
}
