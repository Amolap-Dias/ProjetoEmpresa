using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    class Perfil
    {
        public int id { get; set; }
        public String nome { get; set; }
        public Boolean cad_usuario { get; set; }
        public Boolean cad_perfil { get; set; }
        public Boolean cad_setor { get; set; }
        public Boolean cad_funcionario { get; set; }
        public Boolean rel_setor { get; set; }
        public Boolean rel_funcionario { get; set; }
        public Boolean status { get; set; } 
    }
}
