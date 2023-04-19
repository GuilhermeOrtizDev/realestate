using DevIO.Data.Context;
using DevIO.Data.DTOs;
using DevIO.Data.Repository;
using DevIO.Data.Repositorys.Interface;

namespace DevIO.Data.Repositorys
{
    public class GalleryRepository : Repository<GalleryDTO>, IGalleryRepository
    {
        public GalleryRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
