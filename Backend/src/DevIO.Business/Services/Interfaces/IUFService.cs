using DevIO.Infrastructure.Requests;
using DevIO.Infrastructure.Responses;

namespace DevIO.Business.Services.Interfaces
{
    public interface IUFService : IDisposable
    {
        Task<int?> Create(UFRequest request);
        Task<UFResponse?> Read(int id);
        Task<int?> Update(UFRequest request);
        Task<IEnumerable<UFResponse?>> All();
    }
}
