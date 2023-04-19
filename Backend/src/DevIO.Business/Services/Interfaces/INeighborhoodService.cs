using DevIO.Infrastructure.Requests;
using DevIO.Infrastructure.Responses;

namespace DevIO.Business.Services.Interfaces
{
    public interface INeighborhoodService : IDisposable
    {
        Task<int?> Create(NeighborhoodRequest request);
        Task<NeighborhoodResponse?> Read(int id);
        Task<int?> Update(NeighborhoodRequest request);
        Task<IEnumerable<NeighborhoodResponse?>> All();
    }
}
