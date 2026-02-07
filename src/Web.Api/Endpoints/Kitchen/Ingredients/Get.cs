
using Application.Abstractions.Messaging;
using Application.DTOs.Kitchen.Ingredients;
using Application.UseCases.Kitchen.Ingredients.Get;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Kitchen.Ingredients;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("v1/ingredients", async (
            [FromQuery]bool? isInactive,
            IQueryHandler<GetIngredientsQuery, List<IngredientDto>> handler,
            CancellationToken cancellationToken) =>
        {
            var query = new GetIngredientsQuery();

            Result<List<IngredientDto>> result = await handler.Handle(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Ingredients)
        .RequireAuthorization();
    }
}
