using DevIO.Business.Validations.Interfaces;
using DevIO.Infrastructure.Requests;
using FluentValidation;

namespace DevIO.Business.Validations
{
    public class NeighborhoodValidation : Validation<NeighborhoodRequest>, INeighborhoodValidation
    {
        public new void Create(NeighborhoodRequest request)
        {
            RuleFor(c => c.Description)
              .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");
            RuleFor(c => c.CityId)
              .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");
            Check(request);
        }

        public new void Update(NeighborhoodRequest request)
        {
            RuleFor(c => c.Id)
               .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");
            RuleFor(c => c.Description)
              .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");
            RuleFor(c => c.CityId)
              .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            Check(request);
        }

    }
}
