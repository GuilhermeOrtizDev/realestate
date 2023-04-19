using DevIO.Business.Validations.Interfaces;
using DevIO.Data.DTOs;
using DevIO.Data.Repositorys;
using DevIO.Data.Repositorys.Interface;
using DevIO.Infrastructure.Requests;
using FluentValidation;
using System.Linq.Expressions;

namespace DevIO.Business.Validations
{
    public class CityValidation : Validation<CityRequest>, ICityValidation
    {
        private readonly ICityRepository _cityRepository;

        public CityValidation(
            ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async new Task Create(CityRequest request)
        {
            RuleFor(c => c.UFId)
               .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");
            RuleFor(c => c.Description)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} é obrigatorio")
                .MustAsync(async (c, t) => !(await _cityRepository.Search(new List<Expression<Func<CityDTO, bool>>> { u => u.Description == c })).Any())
                    .WithMessage("Cidade ja existe");

            await CheckAsync(request);
        }

        public async new Task Update(CityRequest request)
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");
            RuleFor(c => c.UFId)
               .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");
            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatorio")
                .MustAsync(async (c, t) => !(await _cityRepository.Search(new List<Expression<Func<CityDTO, bool>>>
                                                                { u => u.Description == c &&  u.Id != request.Id })).Any()).WithMessage("Cidade ja existe");

            await CheckAsync(request);
        }

    }
}
