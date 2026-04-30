namespace GameStore.Api.DTOS.Users;

public record UpdateUserByAdminRequest(
    string Name,
    string Email,
    string Role
);

