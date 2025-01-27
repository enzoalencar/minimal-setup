using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Authorization;

namespace Minimal.Api.Endpoints.Authentication;

[HttpGet("/api/login")]
[AllowAnonymous]
public class LoginEndpoint : EndpointWithoutRequest<TokenResponse>
{
    public override async Task HandleAsync(CancellationToken c)
    {
        Response = await CreateTokenWith<MyTokenService>("User", u =>
        {
            u.Roles.Add("Admin");
            u.Claims.Add(new("UserId", "User"));
        });
    }
}