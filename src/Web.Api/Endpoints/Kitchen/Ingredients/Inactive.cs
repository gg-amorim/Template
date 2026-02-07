
using Application.Abstractions.Messaging;
using Application.UseCases.Kitchen.Ingredients.Inactive;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Kitchen.Ingredients;

internal sealed class Inactive : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("v1/ingredients/{ingredientId:guid}/inactive", async (
           Guid ingredientId,
           ICommandHandler<InactiveIngredientCommand> handler,
           CancellationToken cancellationToken) =>
        {
            var command = new InactiveIngredientCommand(ingredientId);

            Result result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
       .WithTags(Tags.Ingredients)
       .RequireAuthorization();
    }
}
