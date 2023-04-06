using DevIO.Business.Request;
using DevIO.Business.Response;

namespace DevIO.Business.Services
{
    public interface ICityService : IDisposable
    {
        Task<int?> Create(CityRequest request);
        Task<CityResponse?> Read(int id);
        Task<int?> Update(CityRequest request);
        Task<IEnumerable<CityResponse?>> All();
    }
}
