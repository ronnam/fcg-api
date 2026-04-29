namespace GameStore.Api.DTOS;

public record UpdateUserByAdminRequest(
    string Name,
    string Email,
    string Role
);

