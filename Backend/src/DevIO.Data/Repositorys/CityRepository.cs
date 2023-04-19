using DevIO.Data.Context;
using DevIO.Data.DTOs;
using DevIO.Data.Repository;
using DevIO.Data.Repositorys.Interface;

namespace DevIO.Data.Repositorys
{
    public class CityRepository : Repository<CityDTO>, ICityRepository
    {
        public CityRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
