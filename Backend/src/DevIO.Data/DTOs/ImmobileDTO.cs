using DevIO.Infrastructure.Requests;
using DevIO.Infrastructure.Responses;

namespace DevIO.Data.DTOs
{
    public class ImmobileDTO : BaseDTO
    {
        public string Reference { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public AddressDTO Address { get; set; }
        public int AddressId { get; set; }
        public IEnumerable<GalleryDTO>? Gallery { get; set; }

        public static implicit operator ImmobileResponse?(ImmobileDTO? dto) =>
            dto == null ? null
            : new()
            {
                Id = dto.Id,
                Reference = dto.Reference,
                Price = dto.Price,
                Description = dto.Description,
                Created = dto.Created,
                Cep = dto.Address.Cep,
                Logradouro = dto.Address.Logradouro,
                Number = dto.Address.Number,
                Complement = dto.Address.Complement,
                City = dto.Address.City,
                Neighborhood = dto.Address.Neighborhood,
                UF = dto.Address.UF,
                Image = dto.Gallery?.Where(i => i.Emphasis).Select(i => i.File).FirstOrDefault(),
                Gallery = dto.Gallery?.Select(g => g.File).ToList()
            };

        public static implicit operator ImmobileDTO(ImmobileRequest request)
        {
            var dto = new ImmobileDTO()
            {
                Description = request.Description,
                Reference = request.Reference,
                Price = request.Price.Value,
                Address = new AddressDTO
                {
                    Cep = request.Cep,
                    Complement = request.Complement,
                    Logradouro = request.Logradouro,
                    Number = request.Number,
                    UFId = request.UF.Value,
                    CityId = request.City.Value,
                    NeighborhoodId = request.Neighborhood.Value,
                },
                Gallery = request.Gallery?.Select(g => new GalleryDTO
                {
                    File = g,
                    Emphasis = false
                })
            };

            if (request.Id.HasValue)
                dto.Id = request.Id.Value;

            var gallery = new List<GalleryDTO>()
            {
                new GalleryDTO
                {
                    File = request.Image,
                    Emphasis = true
                }
            };

            if (request.Gallery?.Any() ?? false)
                gallery.AddRange(request.Gallery.Select(g => new GalleryDTO
                {
                    File = g,
                    Emphasis = false
                }).ToList());

            dto.Gallery = gallery;

            return dto;
        }
    }
}
