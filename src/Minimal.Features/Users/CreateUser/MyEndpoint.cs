// using FastEndpoints;
// // using Microsoft.AspNetCore.Authorization;
// using Minimal.Features.User.CreateUser;

// namespace Minimal.Features.User.CreateUser.Endpoint;

// public class MyEndpoint : Endpoint<MyRequest, MyResponse>
// {
//     public override async Task HandleAsync(MyRequest req, CancellationToken ct)
//     {
//         await SendAsync(new()
//         {
//             FullName = req.FirstName + " " + req.LastName,
//             IsOver18 = req.Age > 18
//         });
//     }
// }
