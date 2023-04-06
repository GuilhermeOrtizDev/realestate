using DevIO.Business.DTOs;
using DevIO.Business.Repositorys;
using DevIO.Business.Request;
using DevIO.Business.Response;
using DevIO.Business.Services;

namespace DevIO.Data.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<int?> Create(CityRequest request)
        {
            return await _cityRepository.Create(request);
        }

        public async Task<CityResponse?> Read(int id)
        {
            var city = await _cityRepository.Read(id);

            if (city == null)
                return null;

            return city;
        }

        public async Task<int?> Update(CityRequest request)
        {
            if (!request.Id.HasValue)
                return null;

            return await _cityRepository.Update(request);
        }

        public async Task<IEnumerable<CityResponse?>> All()
        {
            return (await _cityRepository.All()).Select<CityDTO, CityResponse?>(dto => dto);
        }

        public void Dispose()
        {
            _cityRepository?.Dispose();
        }

    }
}
