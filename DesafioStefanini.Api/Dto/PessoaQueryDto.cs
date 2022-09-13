using DesafioStefanini.Domain.Entities;

namespace DesafioStefanini.Api.Dto
{
    public class PessoaQueryDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public virtual Cidade Cidade { get; set; }
    }
}
