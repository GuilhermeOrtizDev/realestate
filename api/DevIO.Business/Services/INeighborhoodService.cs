using DevIO.Business.Request;
using DevIO.Business.Response;

namespace DevIO.Business.Services
{
    public interface INeighborhoodService : IDisposable
    {
        Task<int?> Create(NeighborhoodRequest request);
        Task<NeighborhoodResponse?> Read(int id);
        Task<int?> Update(NeighborhoodRequest request);
        Task<IEnumerable<NeighborhoodResponse?>> All();
    }
}
