using DevIO.Business.Request;
using DevIO.Business.Response;

namespace DevIO.Business.Services
{
    public interface IUFService : IDisposable
    {
        Task<int?> Create(UFRequest request);
        Task<UFResponse?> Read(int id);
        Task<int?> Update(UFRequest request);
        Task<IEnumerable<UFResponse?>> All();
    }
}
