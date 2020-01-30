using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empresa
{
    public partial class FrmUsuario : Form
    {
        Usuario usuario1;

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void lerDados()
        {
            usuario1.id = int.Parse(txtID.ToString().Trim());
            usuario1.nome = txtNome.Text;
            usuario1.email = txtEmail.Text;
            usuario1.senha = txtSenha.Text;
            usuario1.status = Boolean.Parse(txtStatus.ToString().Trim*)
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
