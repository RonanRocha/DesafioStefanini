using DesafioStefanini.Data.Repositories;
using DesafioStefanini.Domain.Entities;
using DesafioStefanini.Domain.Repositories;
using DesafioStefanini.Domain.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioStefanini.IoC.ServiceContainer
{
    public static class NativeServiceContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();

            services.AddValidatorsFromAssemblyContaining<PessoaValidator>();
        }
    }
}
