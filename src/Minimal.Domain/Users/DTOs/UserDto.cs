namespace Minimal.Domain.Users.DTOs;

public sealed class UserDto(Guid id, string name, string email)
{
    public Guid Id { get; init; } = id;
    public string Name { get; init; } = name;
    public string Email { get; init; } = email;
}