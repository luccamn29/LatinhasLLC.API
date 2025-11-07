using FluentValidation;

namespace LatinhasLLC.API.Application.Models.DemandItem.Requests;

public class DemandItemRequestValidator : AbstractValidator<DemandItemRequest>
{
    public DemandItemRequestValidator()
    {
        RuleFor(x => x.DemandId)
            .NotEmpty()
            .WithMessage("O identificador da demanda é obrigatório.");

        RuleFor(x => x.SKU)
            .NotEmpty()
            .WithMessage("O SKU é obrigatório.")
            .MaximumLength(50)
            .WithMessage("O SKU deve ter no máximo 50 caracteres.");

        RuleFor(x => x.TotalPlanned)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O total planejado deve ser maior ou igual a zero.");

        RuleFor(x => x.TotalProduced)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O total produzido deve ser maior ou igual a zero.")
            .LessThanOrEqualTo(x => x.TotalPlanned)
            .WithMessage("O total produzido não pode ser maior que o total planejado.");
    }
}
