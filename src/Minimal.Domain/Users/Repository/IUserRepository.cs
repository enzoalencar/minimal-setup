namespace Minimal.Domain.Users.Repository;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken ct);
}