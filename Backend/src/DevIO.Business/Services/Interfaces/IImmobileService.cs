using DevIO.Infrastructure.Requests;
using DevIO.Infrastructure.Responses;

namespace DevIO.Business.Services.Interfaces
{
    public interface IImmobileService : IDisposable
    {
        Task<int?> Create(ImmobileRequest request);
        Task<ImmobileResponse?> Read(int id);
        Task<ImmobileResponse?> ReadWithRef(string refe);
        Task<int?> Update(ImmobileRequest request);
        Task<int?> Delete(int id);
        Task<int?> Active(int id);
        Task<int?> Duplicate(int id);
        Task<IEnumerable<ImmobileResponse?>> All();
        Task<IEnumerable<ImmobileResponse?>> Search(ImmobileRequest request);
    }
}
