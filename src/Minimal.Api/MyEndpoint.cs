using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

[HttpPost("/api/user/create")]
[AllowAnonymous]
public class MyEndpoint : Endpoint<MyRequest, MyResponse>
{
    public override async Task HandleAsync(MyRequest req, CancellationToken ct)
    {
        await SendAsync(new()
        {
            FullName = req.FirstName + " " + req.LastName,
            IsOver18 = req.Age > 18
        });
    }
}
