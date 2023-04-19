using DevIO.Business.Services.Interfaces;
using DevIO.Business.Validations.Interfaces;
using DevIO.Data.DTOs;
using DevIO.Data.Repositorys.Interface;
using DevIO.Infrastructure.Requests;
using DevIO.Infrastructure.Responses;

namespace DevIO.Business.Services
{
    public class UFService : IUFService
    {
        private readonly IUFRepository _ufRepository;
        private readonly IUFValidation _uFValidation;

        public UFService(
            IUFRepository ufRepository,
            IUFValidation uFValidation)
        {
            _ufRepository = ufRepository;
            _uFValidation = uFValidation;
        }

        public async Task<int?> Create(UFRequest request)
        {
            await _uFValidation.Create(request);
            return await _ufRepository.Create(request);
        }

        public async Task<UFResponse?> Read(int id)
        {
            _uFValidation.GetById(id);
            var uf = await _ufRepository.Read(id);

            if (uf == null)
                return null;

            return uf;
        }

        public async Task<int?> Update(UFRequest request)
        {
            await _uFValidation.Update(request);
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
