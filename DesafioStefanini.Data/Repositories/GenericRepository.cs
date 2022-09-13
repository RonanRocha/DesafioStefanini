using DesafioStefanini.Data.Contexts;
using DesafioStefanini.Domain.Filters;
using DesafioStefanini.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioStefanini.Data.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        protected AppDataContext _ctx;

        public GenericRepository(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task DeleteById(TKey id)
        {
            TEntity? entity = await  _ctx.Set<TEntity>().FindAsync(id);
            _ctx.Set<TEntity>().Remove(entity);
            await _ctx.SaveChangesAsync();
        }

        public async  Task<IList<TEntity>> GetAll()
        {
            return await _ctx.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<IList<TEntity>> GetAllPaged(PaginationFilter filter)
        {
            return await _ctx.Set<TEntity>().Skip((filter.PageNumber - 1) * filter.PageSize)
                                     .Take(filter.PageSize)
                                     .ToListAsync();
        }

        public async Task<TEntity> GetById(TKey id)
        {
            return await _ctx.Set<TEntity>().FindAsync(id);
        }

        public async  Task Save(TEntity entity)
        {
             _ctx.Set<TEntity>().Add(entity);
            await _ctx.SaveChangesAsync();
        }

        public  async Task Update(TEntity entity)
        {
            _ctx.Set<TEntity>().Update(entity);
            await _ctx.SaveChangesAsync();
        }
    }
}
