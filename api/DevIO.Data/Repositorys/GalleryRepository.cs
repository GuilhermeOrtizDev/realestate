using DevIO.Business.DTOs;
using DevIO.Business.Repositorys;
using DevIO.Data.Context;
using DevIO.Data.Repository;

namespace DevIO.Data.Repositorys
{
    public class GalleryRepository : Repository<GalleryDTO>, IGalleryRepository
    {
        public GalleryRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
