using DevIO.Business.DTOs;
using DevIO.Business.Repositorys;
using DevIO.Business.Request;
using DevIO.Business.Response;
using DevIO.Business.Services;

namespace DevIO.Data.Services
{
    public class NeighborhoodService : INeighborhoodService
    {
        private readonly INeighborhoodRepository _neighborhoodRepository;

        public NeighborhoodService(INeighborhoodRepository neighborhoodRepository)
        {
            _neighborhoodRepository = neighborhoodRepository;
        }

        public async Task<int?> Create(NeighborhoodRequest request)
        {
            return await _neighborhoodRepository.Create(request);
        }

        public async Task<NeighborhoodResponse?> Read(int id)
        {
            var neighborhood = await _neighborhoodRepository.Read(id);

            if (neighborhood == null)
                return null;

            return neighborhood;
        }

        public async Task<int?> Update(NeighborhoodRequest request)
        {
            if (!request.Id.HasValue)
                return null;

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
