using Minimal.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Minimal.Features.Users.Queries;

public static class ListUsers
{
    public sealed class Response(List<UserDto> users)
    {
        public List<UserDto> Users { get; init; } = users ?? [];
    }

    public sealed class UserDto(Guid id, string name, string email)
    {
        public Guid Id { get; init; } = id;
        public string Name { get; init; } = name;
        public string Email { get; init; } = email;
    }

    public sealed class Handler(AppDbContext dbContext)
    {
        private readonly AppDbContext _dbContext = dbContext;
        
        public async Task<Response> ExecuteAsync(CancellationToken ct)
        {
            var users = await (
                from user in _dbContext.Users
                select new UserDto(user.Id, user.Name ?? string.Empty, user.Email ?? string.Empty)
            ).ToListAsync(ct);

            return new Response(users);
        }
    }
}