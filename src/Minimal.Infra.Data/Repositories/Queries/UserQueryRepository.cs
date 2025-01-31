using Microsoft.EntityFrameworkCore;
using Minimal.Domain.Users.DTOs;
using Minimal.Domain.Users.Repository;

namespace Minimal.Infra.Data.Repositories.Queries;

public class UserQueryRepository(AppDbContext dbContext) : IUserQueryRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<List<UserDto>> GetUsersAsync(CancellationToken ct)
    {
        return await 
        (
            from user in _dbContext.Users
            select new UserDto(user.Id, user.Name ?? string.Empty, user.Email ?? string.Empty)
        ).ToListAsync(ct);
    }
}