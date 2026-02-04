using Application.Abstractions.Messaging;

namespace Application.UseCases.Users.Login;

public sealed record LoginUserCommand(string Email, string Password) : ICommand<string>;
