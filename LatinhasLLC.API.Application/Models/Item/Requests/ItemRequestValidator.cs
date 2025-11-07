using FluentValidation;

namespace LatinhasLLC.API.Application.Models.Item.Requests;

public class ItemRequestValidator : AbstractValidator<ItemRequest>
{
    public ItemRequestValidator()
    {
        RuleFor(x => x.SKU)
            .NotEmpty()
            .WithMessage("O SKU é obrigatório.")
            .MaximumLength(50)
            .WithMessage("O SKU deve ter no máximo 50 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("A descrição é obrigatória.")
            .MaximumLength(200)
            .WithMessage("A descrição deve ter no máximo 200 caracteres.");
    }
}
