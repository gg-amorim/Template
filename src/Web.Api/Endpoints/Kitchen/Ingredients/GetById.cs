
using Application.Abstractions.Messaging;
using Application.DTOs.Kitchen.Ingredients;
using Application.UseCases.Kitchen.Ingredients.Get;
using Application.UseCases.Kitchen.Ingredients.GetById;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Kitchen.Ingredients;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("v1/ingredients/{ingredientId:guid}", async (
            Guid ingredientId,
            [FromQuery]bool? isInactive,
            IQueryHandler<GetIngredientByIdQuery, IngredientDto> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new GetIngredientByIdQuery(ingredientId, isInactive);

            Result<IngredientDto> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Ingredients)
        .RequireAuthorization();
    }
}
