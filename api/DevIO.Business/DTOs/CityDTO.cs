using DevIO.Business.Request;
using DevIO.Business.Response;

namespace DevIO.Business.DTOs
{
    public class CityDTO : BaseDTO
    {
        public string Description { get; set; }
        public IEnumerable<AddressDTO> Address { get; set; }
        public int UFId { get; set; }
        public UFDTO UF { get; set; }
        public IEnumerable<NeighborhoodDTO> Neighborhoods { get; set; }

        public static implicit operator CityResponse?(CityDTO dto) =>
             dto == null ? null
            : new()
            {
                Id = dto.Id,
                Description = dto.Description,
                UFID = dto.UFId,
            };

        public static implicit operator CityDTO(CityRequest request)
        {
            var dto = new CityDTO
            {
                Description = request.Description,
            };

            if (request.Id.HasValue)
                dto.Id = request.Id.Value;

            if (request.UFId.HasValue)
                dto.UFId = request.UFId.Value; 

            return dto;
        }
        
        
    }
}
