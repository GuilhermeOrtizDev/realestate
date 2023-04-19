using DevIO.Data.Context;
using DevIO.Data.DTOs;
using DevIO.Data.Repository;
using DevIO.Data.Repositorys.Interface;

namespace DevIO.Data.Repositorys
{
    public class UFRepository : Repository<UFDTO>, IUFRepository
    {
        public UFRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
