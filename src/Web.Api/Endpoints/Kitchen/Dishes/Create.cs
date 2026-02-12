
using Application.Abstractions.Messaging;
using Application.UseCases.Kitchen.Dishes.Create;
using Application.UseCases.Kitchen.Ingredients.Create;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Kitchen.Dishes;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("v1/dishes", async (
             [FromBody] CreateDishCommand command,
             [FromServices] ICommandHandler<CreateDishCommand, Guid> handler,
             CancellationToken cancellationToken) =>
        {

            Result<Guid> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
         .WithTags(Tags.Dishes)
         .RequireAuthorization();
    }
}
