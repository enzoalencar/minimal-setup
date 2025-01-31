using Minimal.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Minimal.Domain.Users.Repository;
using Minimal.Domain.Users.DTOs;

namespace Minimal.Features.Users.Queries;

public static class ListUsers
{
    public sealed class Response(List<UserDto> users)
    {
        public List<UserDto> Users { get; init; } = users ?? [];
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