using System.Security.Cryptography;
using FastEndpoints;
using FastEndpoints.Security;

public class MyTokenService : RefreshTokenService<TokenRequest, TokenResponse>
{
    public MyTokenService()
    {
        Setup(o =>
        {
            o.TokenSigningKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            o.AccessTokenValidity = TimeSpan.FromMinutes(5);
            o.RefreshTokenValidity = TimeSpan.FromHours(4);

            o.Endpoint("/api/refresh-token", ep =>
            {
                ep.AllowAnonymous();
            });
        });
    }

    public override async Task PersistTokenAsync(TokenResponse response)
    {
        // TODO     
    }

    public override async Task RefreshRequestValidationAsync(TokenRequest req)
    {
        // TODO      
    }

    public override async Task SetRenewalPrivilegesAsync(TokenRequest request, UserPrivileges privileges)
    {
        // TODO      
    }
}