using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Empresa
{
    public partial class FrmLogin : Form
    {
        Usuario usuario1;
        Conexao con;

        public FrmLogin()
        {
            InitializeComponent();
        }

        public void lerDados()
        {
            usuario1 = new Usuario();
            usuario1.usuario = txtUsuario.Text.Trim();
            usuario1.senha = txtSenha.Text.Trim();
            String senhaCry = CrypHash.ComputeSha256Hash(usuario1.senha); 
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lerDados();
            String senhaCry = CrypHash.ComputeSha256Hash(usuario1.senha);
            con.OpenConnection();

            String sql = $"SELECT * FROM tb_usuario WHERE usuario = '{usuario1.usuario} ' AND senha = ' {senhaCry}'";
            MySqlDataReader reader;
            reader = con.executeQuery(sql);

            if (reader.HasRows) //(con.OpenConnection())
            {
                MessageBox.Show("Conectou.");
              //  FrmPrincipal Principal = new FrmPrincipal();

            }
            else
            {
                MessageBox.Show("Não conectou");
            }


        }

       
    }
}
