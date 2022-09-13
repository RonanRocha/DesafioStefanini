using DesafioStefanini.Domain.Entities;
using DesafioStefanini.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStefanini.Domain.Repositories
{
    public  interface IPessoaRepository : IGenericRepository<Pessoa,int>
    {
        public Task<List<Pessoa>> GetPessoasWithCidadesPaged(PaginationFilter filter);
        public Task<Pessoa> GetPessoaWithCidade(int id);
    }
}
