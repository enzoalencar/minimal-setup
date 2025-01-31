using FastEndpoints;
using FluentValidation;
using Minimal.Domain.Users;
using ILogger = Serilog.ILogger;
using Minimal.Domain.Shared.Enums;
using Minimal.Domain.Users.Repository;

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

    public sealed class Handler(IUserRepository userRepository, ILogger logger) : ICommandHandler<Command, Response>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ILogger _logger = logger;

        public async Task<Response> ExecuteAsync(Command command, CancellationToken ct)
        {
            var user = User.Factory.Create(command.Name, command.Email, command.PhoneNumber);

            await _userRepository.AddAsync(user, ct);

            _logger.Information("User created: {@User}", user);

            return new Response(user);
        }
    }
}
