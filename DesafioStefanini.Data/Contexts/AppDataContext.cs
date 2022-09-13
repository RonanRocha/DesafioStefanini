using DesafioStefanini.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioStefanini.Data.Contexts
{
    public  class AppDataContext : DbContext
    {
        public AppDataContext()
        {

        }

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
    }
}
