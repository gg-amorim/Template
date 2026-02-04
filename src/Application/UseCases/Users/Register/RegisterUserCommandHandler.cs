using Application.Abstractions.Authentication;

using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Abstractions.Repositories.Users;
using Domain.Entities.Users;
using SharedKernel;

namespace Application.UseCases.Users.Register;

internal sealed class RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        if (!await userRepository.IsEmailUniqueAsync(command.Email, cancellationToken))
        {
            return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        }

        var user = new User
        {
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            PasswordHash = passwordHasher.Hash(command.Password)
        };

        user.Raise(new UserRegisteredDomainEvent(user.Id));

        await userRepository.CreateAsync(user);

        await unitOfWork.Commit(cancellationToken);

        return user.Id;
    }
}
