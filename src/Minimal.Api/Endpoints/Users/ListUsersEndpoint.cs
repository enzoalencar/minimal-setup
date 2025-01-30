using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using Minimal.Features.Users.Queries;

namespace Minimal.Api.Endpoints.Users;

[HttpGet("/user/list")]
[AllowAnonymous]
public class ListUsersEndpoint : EndpointWithoutRequest<ListUsers.Response>
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        var handler = Resolve<ListUsers.Handler>();
        var res = await handler.ExecuteAsync(ct);
        
        await SendAsync(res, cancellation: ct);
    }
}
