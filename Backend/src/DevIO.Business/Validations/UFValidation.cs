using DevIO.Business.Validations.Interfaces;
using DevIO.Data.DTOs;
using DevIO.Data.Repositorys.Interface;
using DevIO.Infrastructure.Requests;
using FluentValidation;
using System.Linq.Expressions;

namespace DevIO.Business.Validations
{
    public class UFValidation : Validation<UFRequest>, IUFValidation
    {
        private readonly IUFRepository _ufRepository;

        public UFValidation(IUFRepository ufRepository)
        {
            _ufRepository = ufRepository;
        }

        public async new Task Create(UFRequest request)
        {
            RuleFor(c => c.Description)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} é obrigatorio")
                .MustAsync(async (c, t) => !(await _ufRepository.Search(new List<Expression<Func<UFDTO, bool>>> { u => u.Description == c })).Any())
                    .WithMessage("UF ja existe");

            await CheckAsync(request);
        }

        public async new Task Update(UFRequest request)
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio")
            .MustAsync(async (c, t) => !(await _ufRepository.Search(new List<Expression<Func<UFDTO, bool>>> 
                                                                { u => u.Description == c &&  u.Id != request.Id })).Any()).WithMessage("UF ja existe");

            await CheckAsync(request);
        }

    }
}
