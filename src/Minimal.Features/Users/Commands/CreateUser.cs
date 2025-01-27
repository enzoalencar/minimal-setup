namespace Minimal.Features.Users.Commands;

public class CreateUserRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Age { get; set; }
}

public class CreateUserResponse
{
    public string? FullName { get; set; }
    public bool IsOver18 { get; set; }
}