using DevIO.Infrastructure.Requests;
using DevIO.Infrastructure.Responses;

namespace DevIO.Data.DTOs
{
    public class NeighborhoodDTO : BaseDTO
    {
        public string Description { get; set; }
        public IEnumerable<AddressDTO> Address { get; set; }
        public int CityId { get; set; }
        public CityDTO City { get; set; }

        public static implicit operator NeighborhoodResponse?(NeighborhoodDTO dto) =>
             dto == null ? null
            : new()
            {
                Id = dto.Id,
                Description = dto.Description,
                CityId = dto.CityId,

            };

        public static implicit operator NeighborhoodDTO(NeighborhoodRequest request)
        {
            var dto = new NeighborhoodDTO
            {
                Description = request.Description
            };

            if (request.Id.HasValue)
                dto.Id = request.Id.Value;

            if (request.CityId.HasValue)
                dto.CityId = request.CityId.Value;

            return dto;
        }
    }
}
