using DevIO.Business.Validations.Interfaces;
using DevIO.Data.Repositorys.Interface;
using DevIO.Infrastructure.Requests;
using FluentValidation;

namespace DevIO.Business.Validations
{
    public class ImmobileValidation : Validation<ImmobileRequest>, IImmobileValidation
    {
        private readonly IImmobileRepository _immobileRepository;

        public ImmobileValidation(
            IImmobileRepository immobileRepository)
        {
            _immobileRepository = immobileRepository;
        }

        public void GetByRef(string refe)
        {
            var request = new ImmobileRequest { Reference = refe };

            RuleFor(c => c.Reference)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            Check(request);
        }

        public async new Task Create(ImmobileRequest request)
        {
            UPIsRequired();

            RuleFor(c => c.Reference)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} é obrigatorio")
                .MustAsync(async (c, t) => c != null && (await _immobileRepository.ReadWithRef(c)) == null)
                    .WithMessage("Referencia ja existe");

            await CheckAsync(request);
        }

        public async new Task Update(ImmobileRequest request)
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            RuleFor(c => c.Reference)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} é obrigatorio")
                .MustAsync(async (c, t) => c != null && (await _immobileRepository.ReadWithRef(c))?.Id != request.Id)
                    .WithMessage("UF ja existe");

            UPIsRequired();
            await CheckAsync(request);
        }

        private void UPIsRequired()
        {
            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio")
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {ExpectedScale} caracter");

            RuleFor(c => c.UF)
               .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            RuleFor(c => c.City)
               .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            RuleFor(c => c.Neighborhood)
               .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            RuleFor(c => c.Logradouro)
               .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            RuleFor(c => c.Description)
               .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            RuleFor(c => c.Image)
               .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");
        }

    }
}
