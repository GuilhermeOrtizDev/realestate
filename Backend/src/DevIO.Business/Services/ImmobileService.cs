using DevIO.Business.Services.Interfaces;
using DevIO.Business.Validations.Interfaces;
using DevIO.Data.DTOs;
using DevIO.Data.Repositorys.Interface;
using DevIO.Infrastructure.Requests;
using DevIO.Infrastructure.Responses;
using System.Linq.Expressions;

namespace DevIO.Business.Services
{
    public class ImmobileService : IImmobileService
    {
        private readonly IImmobileRepository _immobileRepository;
        private readonly IImmobileValidation _immobileValidation;

        public ImmobileService(
            IImmobileRepository immobileRepository,
            IImmobileValidation validations)
        {
            _immobileRepository = immobileRepository;
            _immobileValidation = validations;
        }

        public async Task<int?> Create(ImmobileRequest request)
        {
            await _immobileValidation.Create(request);
            return await _immobileRepository.Create(request);
        }

        public async Task<ImmobileResponse?> Read(int id)
        {
            _immobileValidation.GetById(id);
            var immobile = await _immobileRepository.Read(id);

            if (immobile == null)
                return null;

            return immobile;
        }

        public async Task<ImmobileResponse?> ReadWithRef(string refe)
        {
            _immobileValidation.GetByRef(refe);
            var immobile = await _immobileRepository.ReadWithRef(refe);

            if (immobile == null)
                return null;

            return immobile;
        }

        public async Task<int?> Update(ImmobileRequest request)
        {
            await _immobileValidation.Update(request);
            return await _immobileRepository.Update(request);
        }

        public async Task<int?> Delete(int id)
        {
            _immobileValidation.Delete(id);
            return await _immobileRepository.Delete(id);
        }

        public async Task<int?> Active(int id)
        {
            _immobileValidation.Active(id);
            return await _immobileRepository.Active(id);
        }

        public async Task<int?> Duplicate(int id)
        {
            _immobileValidation.GetById(id);
            return await _immobileRepository.Duplicate(id);
        }

        public async Task<IEnumerable<ImmobileResponse?>> All()
        {
            return (await _immobileRepository.All()).Select<ImmobileDTO, ImmobileResponse?>(dto => dto);
        }

        public async Task<IEnumerable<ImmobileResponse?>> Search(ImmobileRequest request)
        {
            var predicates = new List<Expression<Func<ImmobileDTO, bool>>>();

            if (request.Id.HasValue)
                predicates.Add(dto => dto.Id == request.Id && dto.Reference == request.Reference);

            if (!string.IsNullOrEmpty(request.Reference))
                predicates.Add(dto => dto.Reference == request.Reference);

            if (!string.IsNullOrEmpty(request.Description))
                predicates.Add(dto => dto.Description == request.Description);

            if (!string.IsNullOrEmpty(request.Cep))
                predicates.Add(dto => dto.Address.Cep == request.Cep);

            if (!string.IsNullOrEmpty(request.Complement))
                predicates.Add(dto => dto.Address.Complement == request.Complement);

            if (!string.IsNullOrEmpty(request.Logradouro))
                predicates.Add(dto => dto.Address.Logradouro == request.Logradouro);

            if (!string.IsNullOrEmpty(request.Number))
                predicates.Add(dto => dto.Address.Number == request.Number);

            if (request.Neighborhood.HasValue)
                predicates.Add(dto => dto.Address.NeighborhoodId == request.Neighborhood);

            if (request.UF.HasValue)
                predicates.Add(dto => dto.Address.UFId == request.UF);

            if (request.City.HasValue)
                predicates.Add(dto => dto.Address.CityId == request.City);

            predicates.Add(dto => dto.IsActive);

            var query = (await _immobileRepository.Search(predicates)).Select<dynamic, ImmobileResponse?>(dto => dto).AsQueryable();

            if (request.Orders?.Any() ?? false)
            {
                var orderBy = request.Orders[0].Desc ? query.OrderByDescending(q => request.Orders[0].By) :
                                                        query.OrderBy(q => request.Orders[0].By);

                var orders = request.Orders;
                orders.RemoveAt(0);

                if (orders?.Any() ?? false)
                    foreach (var order in orders)
                        orderBy = order.Desc ? orderBy.ThenByDescending(q => order.By) :
                                               orderBy.ThenBy(q => order.By);

                query = orderBy;
            }
            else query = query.OrderByDescending(q => q.Id).AsQueryable();

            if (request.Take.HasValue && request.Skip.HasValue)
                query = query.Skip(request.Take.Value * request.Skip.Value - request.Take.Value);

            if (request.Take.HasValue)
                return query.Take(request.Take.Value);

            return query;
        }

        public void Dispose()
        {
            _immobileRepository?.Dispose();
        }
    }
}
