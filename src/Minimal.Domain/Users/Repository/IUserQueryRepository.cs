using Minimal.Domain.Users.DTOs;

namespace Minimal.Domain.Users.Repository;

public interface IUserQueryRepository
{
    Task<List<UserDto>> GetUsersAsync(CancellationToken ct);
}