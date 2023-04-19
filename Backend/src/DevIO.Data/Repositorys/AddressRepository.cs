using DevIO.Data.Context;
using DevIO.Data.DTOs;
using DevIO.Data.Repository;
using DevIO.Data.Repositorys.Interface;

namespace DevIO.Data.Repositorys
{
    public class AddressRepository : Repository<AddressDTO>, IAddressRepository
    {
        public AddressRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
