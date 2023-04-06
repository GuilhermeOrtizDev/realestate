using DevIO.Business.DTOs;
using DevIO.Business.Repositorys;
using DevIO.Data.Context;
using DevIO.Data.Repository;

namespace DevIO.Data.Repositorys
{
    public class AddressRepository : Repository<AddressDTO>, IAddressRepository
    {
        public AddressRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
