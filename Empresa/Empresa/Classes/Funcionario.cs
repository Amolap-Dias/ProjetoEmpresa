using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    class Funcionario
    {
        public int id { get; set; }
        public String nome { get; set; }
        public Char cpf { get; set; }
        public DateTime dt_nascimento { get; set; }
        public char sexo { get; set; }
        public String estado_civil { get; set; }
        public Char cep { get; set; }
        public String endereco { get; set; }
        public DateTime dt_admissao { get; set; }
        public Boolean status { get; set; }
        public int id_setor { get; set; }
    }
}
