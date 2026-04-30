namespace GameStore.Api.DTOS.Users
{
    public record RegisterUserRequest(
        string Name,
        string Email,
        string Password
    );
}
