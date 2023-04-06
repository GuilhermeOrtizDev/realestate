using System.Linq.Expressions;

namespace DevIO.Business.Repositorys
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task<int?> Create(TEntity entity);
        Task<TEntity?> Read(int id);
        Task<int?> Update(TEntity entity);
        Task<int?> Delete(int id);
        Task<int?> Active(int id);
        Task<int?> Duplicate (int id);
        Task<IEnumerable<TEntity>> All();
        Task<IEnumerable<TEntity>> Search(List<Expression<Func<TEntity, bool>>> predicates);
        Task<int> SaveChanges();
    }
}