using FluentValidation;

namespace DevIO.Business.Validations.Interfaces
{
    public interface IValidation<TRequest>
    {
        void GetById(int id);
        void Active(int id);
        void Delete(int id);
        void Create(TRequest request);
        void Update(TRequest request);
    }
}
