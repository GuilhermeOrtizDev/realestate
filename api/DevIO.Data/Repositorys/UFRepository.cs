using DevIO.Business.DTOs;
using DevIO.Business.Repositorys;
using DevIO.Data.Context;
using DevIO.Data.Repository;

namespace DevIO.Data.Repositorys
{
    public class UFRepository : Repository<UFDTO>, IUFRepository
    {
        public UFRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
