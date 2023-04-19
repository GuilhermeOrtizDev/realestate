using DevIO.Infrastructure.Requests;

namespace DevIO.Business.Validations.Interfaces
{
    public interface IUFValidation : IValidation<UFRequest>
    {
        new Task Create(UFRequest request);
        new Task Update(UFRequest request);
    }
}
