﻿using System.ComponentModel.DataAnnotations;

namespace DesafioStefanini.Api.Dto
{
    public class CidadeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
    }
}
