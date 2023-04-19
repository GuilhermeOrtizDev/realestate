using DevIO.Data.Context;
using DevIO.Data.DTOs;
using DevIO.Data.Repository;
using DevIO.Data.Repositorys.Interface;

namespace DevIO.Data.Repositorys
{
    public class NeighborhoodRepository : Repository<NeighborhoodDTO>, INeighborhoodRepository
    {
        public NeighborhoodRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
