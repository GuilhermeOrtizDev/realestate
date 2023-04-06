using DevIO.Business.DTOs;
using DevIO.Business.Repositorys;
using DevIO.Business.Request;
using DevIO.Business.Response;
using DevIO.Business.Services;

namespace DevIO.Data.Services
{
    public class UFService : IUFService
    {
        private readonly IUFRepository _ufRepository;

        public UFService(IUFRepository ufRepository)
        {
            _ufRepository = ufRepository;
        }

        public async Task<int?> Create(UFRequest request)
        {
            return await _ufRepository.Create(request);
        }

        public async Task<UFResponse?> Read(int id)
        {
            var uf = await _ufRepository.Read(id);

            if (uf == null)
                return null;

            return uf;
        }

        public async Task<int?> Update(UFRequest request)
        {
            if (!request.Id.HasValue)
                return null;

            return await _ufRepository.Update(request);
        }

        public async Task<IEnumerable<UFResponse?>> All()
        {
            return (await _ufRepository.All()).Select<UFDTO, UFResponse?>(dto => dto);
        }

        public void Dispose()
        {
            _ufRepository?.Dispose();
        }

    }
}
