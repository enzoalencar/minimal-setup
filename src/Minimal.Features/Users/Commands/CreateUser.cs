namespace Minimal.Features.Users.Commands;

public class CreateUserRequest
{
    public string? Name { get; set; }
    public int? Age { get; set; }
}

public class CreateUserResponse
{
    public required string Message { get; set; }
}