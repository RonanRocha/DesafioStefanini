using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStefanini.Domain.Entities
{
    [Table("Pessoa")]
    public  class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [StringLength(300)]
        [Required]
        public string Nome { get; set; }

        [StringLength(11)]
        [Required]
        public string Cpf { get; set; }
        [Required]
        public int Idade { get; set; } 
        public int Id_Cidade { get; set; }

        [ForeignKey("Id_Cidade")]
        public Cidade Cidade { get; set; }
    }
}
