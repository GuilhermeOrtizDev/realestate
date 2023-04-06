using DevIO.Business.Request;
using DevIO.Business.Response;

namespace DevIO.Business.DTOs
{
    public class UFDTO : BaseDTO
    {
        public string Description { get; set; }
        public IEnumerable<AddressDTO> Address { get; set; }
        public IEnumerable<CityDTO> Cities { get; set; }

        public static implicit operator UFResponse?(UFDTO dto) =>
             dto == null ? null
            : new()
            {
                Id = dto.Id,
                Description = dto.Description,
            };

        public static implicit operator UFDTO(UFRequest request)
        {
            var dto = new UFDTO
            {
                Description = request.Description
            };

            if (request.Id.HasValue)
                dto.Id = request.Id.Value;

            return dto;
        }
    }
}
