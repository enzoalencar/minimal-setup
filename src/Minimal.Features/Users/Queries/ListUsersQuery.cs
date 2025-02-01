using Minimal.Domain.Users;
using Minimal.Features.Users.Queries.Repository;

namespace Minimal.Features.Users.Queries;

public static class ListUsers
{
    public sealed class Response(List<User> users)
    {
        public List<User> Users { get; init; } = users ?? [];
    }

    public sealed class Handler(IUserQueryRepository userQueryRepository)
    {
        private readonly IUserQueryRepository _userQueryRepository = userQueryRepository;
        
        public async Task<Response> ExecuteAsync(CancellationToken ct)
        {
            var users = await _userQueryRepository.GetUsersAsync(ct);
            return new Response(users);
        }
    }
}