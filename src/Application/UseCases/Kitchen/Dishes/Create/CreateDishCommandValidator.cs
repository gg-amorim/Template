using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.UseCases.Kitchen.Dishes.Create;

internal sealed class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.SalePrice)
            .GreaterThan(0)
            .WithMessage("SalePrice must be greater than zero.");
        RuleFor(c => c.Ingredients)
             .NotEmpty()
             .WithMessage("At least one ingredient is required.");
    }
}
