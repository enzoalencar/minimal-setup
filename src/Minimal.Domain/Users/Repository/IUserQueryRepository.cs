using Minimal.Domain.Users;

namespace Minimal.Features.Users.Queries.Repository;

public interface IUserQueryRepository
{
    Task<List<User>> GetUsersAsync(CancellationToken ct);
}