using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using Minimal.Features.Users.Commands;

namespace Minimal.Api.Endpoints.Users;

[HttpPost("/user/create")]
[AllowAnonymous]
public class CreateUserEndpoint : Endpoint<CreateUser.Command, CreateUser.Response>
{
    public override async Task HandleAsync(CreateUser.Command command, CancellationToken ct)
    {
        var handler = Resolve<CreateUser.Handler>();
        var res = await handler.ExecuteAsync(command, ct);
        
        await SendAsync(res, cancellation: ct);
    }
}
