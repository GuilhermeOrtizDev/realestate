using DevIO.Infrastructure.Requests;
using DevIO.Infrastructure.Responses;

namespace DevIO.Business.Services.Interfaces
{
    public interface ICityService : IDisposable
    {
        Task<int?> Create(CityRequest request);
        Task<CityResponse?> Read(int id);
        Task<int?> Update(CityRequest request);
        Task<IEnumerable<CityResponse?>> All();
    }
}
