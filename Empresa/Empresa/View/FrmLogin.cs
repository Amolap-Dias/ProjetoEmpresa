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
            usuario1 = new Usuario();
            con = new Conexao();
        }

        public void lerDados()
        {
            usuario1.usuario = txtUsuario.Text.Trim();
            usuario1.senha = txtSenha.Text.Trim();
           // String senhaCry = CrypHash.ComputeSha256Hash(usuario1.senha); 
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con.OpenConnection();
            lerDados();
            String senhaCry = CrypHash.ComputeSha256Hash(usuario1.senha);


            String sql = $"SELECT * FROM tb_usuario WHERE usuario = '{usuario1.usuario} ' AND senha = ' {senhaCry}'";
            MySqlDataReader reader;
            reader = con.executeQuery(sql);

            if (reader.HasRows) //(con.OpenConnection())
            {
                this.Visible = false;
                MessageBox.Show("Conectou.");
                FrmPrincipal Principal = new FrmPrincipal();

                Principal.Show();
                //  FrmPrincipal Principal = new FrmPrincipal();

            }
            else
            {
                MessageBox.Show("Não conectou.");
            }

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
