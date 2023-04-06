using DevIO.Business.DTOs;
using DevIO.Business.Repositorys;
using DevIO.Data.Context;
using DevIO.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevIO.Data.Repositorys
{
    public class ImmobileRepository : Repository<ImmobileDTO>, IImmobileRepository
    {
        private readonly IQueryable<ImmobileDTO> _query;

        public ImmobileRepository(RealEstateDbContext context) : base(context)
        {
            _query = Db.Immobile.AsNoTracking()
                .Include(a => a.Address)
                .Include(a => a.Address.UF)
                .Include(a => a.Address.City)
                .Include(a => a.Address.Neighborhood)
                .Include(g => g.Gallery);
        }

        public new async Task<ImmobileDTO?> Read(int id)
        {
            return await _query
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<ImmobileDTO?> ReadWithRef(string refe)
        {
            return await _query
                .FirstOrDefaultAsync(i => i.Reference.Equals(refe) && i.IsActive);
        }

        public new async Task<IEnumerable<ImmobileDTO>> All()
        {
            return await _query
                .ToListAsync();
        }

        public new async Task<int?> Duplicate(int id)
        {
            var immobile = await Read(id);

            if (immobile == null)
                return null;

            DbSet.Add(immobile);
            return await SaveChanges();
        }

        public new async Task<IEnumerable<ImmobileDTO>> Search(List<Expression<Func<ImmobileDTO, bool>>> predicates)
        {
            var query = _query;

            foreach (var predicate in predicates)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync();
        }
    }
}
