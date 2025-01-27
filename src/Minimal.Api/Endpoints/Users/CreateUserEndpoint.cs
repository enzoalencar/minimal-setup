using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using Minimal.Features.Users.Commands;

namespace Minimal.Api.Endpoints.Users;

[HttpPost("/api/user/create")]
[AllowAnonymous]
public class CreateUserEndpoint : Endpoint<CreateUserRequest, CreateUserResponse>
{
    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        await SendAsync(new()
        {
            FullName = req.FirstName + " " + req.LastName,
            IsOver18 = req.Age > 18
        });
    }
}
