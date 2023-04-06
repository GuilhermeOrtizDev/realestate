using DevIO.Business.DTOs;
using DevIO.Business.Repositorys;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevIO.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : DTO, new()
    {
        protected readonly RealEstateDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(RealEstateDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Search(List<Expression<Func<TEntity, bool>>> predicates)
        {
            var query = DbSet.AsNoTracking();

            foreach (var predicate in predicates)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity?> Read(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> All()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<int?> Create(TEntity entity)
        {
            DbSet.Add(entity);
            var success = await SaveChanges();
            return success == 0 ? success : entity.Id;
        }

        public virtual async Task<int?> Update(TEntity entity)
        {
            DbSet.Update(entity);
            ((dynamic)entity).IsActive = true;
            return await SaveChanges();
        }

        public virtual async Task<int?> Delete(int id)
        {
            return await ActiveOrDesactive(id, false);
        }

        public virtual async Task<int?> Active(int id)
        {
            return await ActiveOrDesactive(id, true);
        }

        public virtual async Task<int?> Duplicate(int id)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity == null)
                return null;

            DbSet.Add(entity);
            return await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        private async Task<int?> ActiveOrDesactive(int id, bool option)
        {
            dynamic? entity = await DbSet.FindAsync(id);

            if (entity == null)
                return null;

            entity.IsActive = option;
            DbSet.Update(entity);
            return await SaveChanges();
        }
    }
}