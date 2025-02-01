using Microsoft.EntityFrameworkCore;
using Minimal.Domain.Users;
using Minimal.Features.Users.Queries.Repository;


namespace Minimal.Infra.Data.Repositories.Queries;

public class UserQueryRepository(AppDbContext dbContext) : IUserQueryRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<List<User>> GetUsersAsync(CancellationToken ct)
    {
        return await _dbContext.Users.ToListAsync(ct);
    }
}