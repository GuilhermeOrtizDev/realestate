using DevIO.Infrastructure.Requests;
using FluentValidation;
using DevIO.Business.Validations.Interfaces;

namespace DevIO.Business.Validations
{
    public class Validation<TRequest> : AbstractValidator<TRequest>, IValidation<TRequest> where TRequest : Request, new()
    {
        public virtual void Active(int id)
        {
            var request = new TRequest { Id = id };

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            Check(request);
        }

        public virtual void Delete(int id)
        {
            var request = new TRequest { Id = id };

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            Check(request);
        }

        public virtual void GetById(int id)
        {
            var request = new TRequest { Id = id };

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatorio");

            Check(request);
        }

        public virtual void Create(TRequest request)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TRequest request)
        {
            throw new NotImplementedException();
        }

        protected void Check(TRequest request)
        {
            var validator = Validate(request);

            if (validator.IsValid)
                return;

            var exceptions = new List<Exception>();

            foreach (var exception in validator.Errors)
                exceptions.Add(new NullReferenceException(exception.ErrorMessage));

            throw new AggregateException("Error", exceptions);

        }

        protected async Task CheckAsync(TRequest request)
        {
            var validator = await ValidateAsync(request);

            if (validator.IsValid)
                return;

            var exceptions = new List<Exception>();

            foreach (var exception in validator.Errors)
                exceptions.Add(new NullReferenceException(exception.ErrorMessage));

            throw new AggregateException("Error", exceptions);

        }
    }
}
