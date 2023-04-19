using DevIO.Business.Services.Interfaces;
using DevIO.Business.Validations.Interfaces;
using DevIO.Data.DTOs;
using DevIO.Data.Repositorys.Interface;
using DevIO.Infrastructure.Requests;
using DevIO.Infrastructure.Responses;

namespace DevIO.Business.Services
{
    public class NeighborhoodService : INeighborhoodService
    {
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly INeighborhoodValidation _neighborhoodValidation;

        public NeighborhoodService(
            INeighborhoodRepository neighborhoodRepository,
            INeighborhoodValidation neighborhoodValidation)
        {
            _neighborhoodRepository = neighborhoodRepository;
            _neighborhoodValidation = neighborhoodValidation;
        }

        public async Task<int?> Create(NeighborhoodRequest request)
        {
            _neighborhoodValidation.Create(request);
            return await _neighborhoodRepository.Create(request);
        }

        public async Task<NeighborhoodResponse?> Read(int id)
        {
            _neighborhoodValidation.GetById(id);
            var neighborhood = await _neighborhoodRepository.Read(id);

            if (neighborhood == null)
                return null;

            return neighborhood;
        }

        public async Task<int?> Update(NeighborhoodRequest request)
        {
            _neighborhoodValidation.Update(request);
            return await _neighborhoodRepository.Update(request);
        }

        public async Task<IEnumerable<NeighborhoodResponse?>> All()
        {
            return  (await _neighborhoodRepository.All()).Select<NeighborhoodDTO, NeighborhoodResponse?>(dto => dto);
        }

        public void Dispose()
        {
            _neighborhoodRepository?.Dispose();
        }
    }
}
