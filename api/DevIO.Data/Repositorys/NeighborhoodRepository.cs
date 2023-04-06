using DevIO.Business.DTOs;
using DevIO.Business.Repositorys;
using DevIO.Data.Context;
using DevIO.Data.Repository;

namespace DevIO.Data.Repositorys
{
    public class NeighborhoodRepository : Repository<NeighborhoodDTO>, INeighborhoodRepository
    {
        public NeighborhoodRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
