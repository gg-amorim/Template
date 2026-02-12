
using Application.Abstractions.Messaging;
using Application.UseCases.Kitchen.Ingredients.Create;
using Application.UseCases.Users.Login;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Kitchen.Ingredients;

internal sealed class Create : IEndpoint
{
    public sealed record Request(string Name, string Unit, decimal CostPrice);
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("v1/ingredients", async (
            [FromBody]CreateIngredientCommand command,
            [FromServices]ICommandHandler<CreateIngredientCommand, Guid> handler,
            CancellationToken cancellationToken) =>
        {

            Result<Guid> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Ingredients)
        .RequireAuthorization();
    }
}
