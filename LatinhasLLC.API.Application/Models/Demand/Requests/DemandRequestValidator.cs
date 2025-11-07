using FluentValidation;

namespace LatinhasLLC.API.Application.Models.Demand.Requests;

public class DemandItemRequestValidator : AbstractValidator<DemandRequest>
{
    public DemandItemRequestValidator()
    {
        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("A data inicial é obrigatória.")
            .LessThanOrEqualTo(x => x.EndDate)
            .WithMessage("A data inicial deve ser anterior ou igual à data final.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("A data final é obrigatória.");
    }
}