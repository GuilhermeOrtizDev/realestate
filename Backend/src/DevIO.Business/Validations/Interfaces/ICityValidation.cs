using DevIO.Infrastructure.Requests;

namespace DevIO.Business.Validations.Interfaces
{
    public interface ICityValidation : IValidation<CityRequest>
    {
        new Task Create(CityRequest request);
        new Task Update(CityRequest request);
    }
}
