using DesafioStefanini.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStefanini.Domain.Repositories
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {

        Task<IList<TEntity>> GetAll();
        Task Save(TEntity entity);
        Task<TEntity> GetById(TKey id);
        Task Update(TEntity entity);
        Task DeleteById(TKey id);
        Task<IList<TEntity>> GetAllPaged(PaginationFilter filter);
    }
}


