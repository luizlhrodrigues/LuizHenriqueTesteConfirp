using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizHenriqueTesteConfirp.Models
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public Sexo Sexo { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }


    }
}
