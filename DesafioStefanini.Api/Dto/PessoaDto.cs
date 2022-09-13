using DesafioStefanini.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioStefanini.Api.Dto
{
    public class PessoaDto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public int Id_Cidade { get; set; }

      
    }
}
