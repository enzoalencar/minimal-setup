using FastEndpoints;
using FluentValidation;
using Minimal.Infra.Data;
using Minimal.Domain.Users;
using ILogger = Serilog.ILogger;
using Minimal.Domain.Shared.Enums;

namespace Minimal.Features.Users.Commands;

public static class CreateUser
{
    public sealed class Command : ICommand<Response>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public sealed class Response(User dto)
    {
        public Guid Id { get; init; } = dto.Id;
        public string? Name { get; init; } = dto.Name;
        public UserStatus Status {get; init; } = dto.Status;
        public string? Email { get; init; } = dto.Email;
        public string? PhoneNumber { get; init; } = dto.PhoneNumber;
        public DateTimeOffset CreatedAt { get; init; } = dto.CreatedAt;
    }

    public sealed class Validator : Validator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Name must be at least 3 characters long!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid email address!");
        }
    }

    public sealed class Handler : ICommandHandler<Command, Response>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger _logger;

        public Handler(AppDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Response> ExecuteAsync(Command command, CancellationToken ct)
        {
            var user = User.Factory.Create(command.Name, command.Email, command.PhoneNumber);

            await _dbContext.Users.AddAsync(user, ct);
            await _dbContext.SaveChangesAsync(ct);

            _logger.Information("User created: {@User}", user);

            return new Response(user);
        }
    }
}
