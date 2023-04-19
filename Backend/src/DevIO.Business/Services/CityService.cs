using DevIO.Business.Services.Interfaces;
using DevIO.Business.Validations.Interfaces;
using DevIO.Data.DTOs;
using DevIO.Data.Repositorys.Interface;
using DevIO.Infrastructure.Requests;
using DevIO.Infrastructure.Responses;

namespace DevIO.Business.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICityValidation _cityValidation;

        public CityService(
            ICityRepository cityRepository,
            ICityValidation cityValidation)
        {
            _cityRepository = cityRepository;
            _cityValidation = cityValidation;
        }

        public async Task<int?> Create(CityRequest request)
        {
            await _cityValidation.Create(request);
            return await _cityRepository.Create(request);
        }

        public async Task<CityResponse?> Read(int id)
        {
            _cityValidation.GetById(id);
            var city = await _cityRepository.Read(id);

            if (city == null)
                return null;

            return city;
        }

        public async Task<int?> Update(CityRequest request)
        {
            await _cityValidation.Update(request);
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
