using DesafioStefanini.Data.Contexts;
using DesafioStefanini.Domain.Entities;
using DesafioStefanini.Domain.Filters;
using DesafioStefanini.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStefanini.Data.Repositories
{
    public class CidadeRepository : GenericRepository<Cidade,int> , ICidadeRepository
    {
        public CidadeRepository(AppDataContext ctx) : base(ctx)
        {

        }

    }
}
