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
    public partial class FrmPrincipal : Form
    {
        public object FrmSetor { get; private set; }

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnSetores_Click(object sender, EventArgs e)
        {
            

        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmUsuario usuario = new FrmUsuario();
            usuario.Show();

        }
    }
}
