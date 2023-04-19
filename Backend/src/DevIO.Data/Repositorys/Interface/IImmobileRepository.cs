using DevIO.Data.DTOs;

namespace DevIO.Data.Repositorys.Interface
{
    public interface IImmobileRepository : IRepository<ImmobileDTO>
    {
        Task<ImmobileDTO?> ReadWithRef(string refe);
    }
}
