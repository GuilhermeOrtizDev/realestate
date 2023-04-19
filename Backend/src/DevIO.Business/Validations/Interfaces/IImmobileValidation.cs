using DevIO.Infrastructure.Requests;

namespace DevIO.Business.Validations.Interfaces
{
    public interface IImmobileValidation : IValidation<ImmobileRequest>
    {
        void GetByRef(string refe);
        new Task Create(ImmobileRequest request);
        new Task Update(ImmobileRequest request);
    }
}
