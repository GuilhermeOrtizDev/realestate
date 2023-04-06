using DevIO.Business.DTOs;

namespace DevIO.Business.Repositorys
{
    public interface IImmobileRepository : IRepository<ImmobileDTO>
    {
        Task<ImmobileDTO?> ReadWithRef(string refe);
    }
}
