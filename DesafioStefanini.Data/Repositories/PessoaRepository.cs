using DesafioStefanini.Data.Contexts;
using DesafioStefanini.Domain.Entities;
using DesafioStefanini.Domain.Filters;
using DesafioStefanini.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioStefanini.Data.Repositories
{
    public class PessoaRepository : GenericRepository<Pessoa,int>, IPessoaRepository
    {
        public PessoaRepository(AppDataContext ctx) : base(ctx)
        {

        }

        public async Task<List<Pessoa>> GetPessoasWithCidadesPaged(PaginationFilter filter)
        {
            return  await _ctx.Pessoas.Include(x => x.Cidade)
                                      .Skip((filter.PageNumber - 1) * filter.PageSize)
                                      .Take(filter.PageSize)
                                      .ToListAsync();
        }

        public async Task<Pessoa> GetPessoaWithCidade(int id)
        {
            return await _ctx.Pessoas
                        .Include(x => x.Cidade)
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();
        }
    }
}
