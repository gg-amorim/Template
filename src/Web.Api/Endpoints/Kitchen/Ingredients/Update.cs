using Application.Abstractions.Messaging;
using Application.UseCases.Kitchen.Ingredients.Create;
using Application.UseCases.Kitchen.Ingredients.Update;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Kitchen.Ingredients;

internal sealed class Update : IEndpoint
{
    public sealed record Request(string Name, string Unit, decimal CostPrice);
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("v1/ingredients/{ingredentId:guid}", async (
            Guid ingredentId,
            Request request,
            ICommandHandler<UpdateIngredientCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateIngredientCommand(ingredentId, request.Name, request.Unit, request.CostPrice);

            Result result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Ingredients)
        .RequireAuthorization();
    }
}
