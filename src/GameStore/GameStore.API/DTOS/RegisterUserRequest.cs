namespace GameStore.Api.DTOS
{
    public record RegisterUserRequest(
        string Name,
        string Email,
        string Password
    );
}
