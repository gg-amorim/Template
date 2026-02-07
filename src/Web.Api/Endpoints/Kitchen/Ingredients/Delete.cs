using Application.Abstractions.Messaging;
using Application.UseCases.Kitchen.Ingredients.Delete;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Kitchen.Ingredients;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("v1/ingredients/{ingredientId:guid}", async (
            Guid ingredientId,
            ICommandHandler<DeleteIngredientCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new DeleteIngredientCommand(ingredientId);

            Result result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Ingredients)
        .RequireAuthorization();
    }
}
