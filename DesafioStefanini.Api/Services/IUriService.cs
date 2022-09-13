using DesafioStefanini.Domain.Filters;

namespace DesafioStefanini.Api.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
