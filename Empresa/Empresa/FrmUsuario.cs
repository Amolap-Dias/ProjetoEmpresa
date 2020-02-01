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
    public partial class FrmUsuario : Form
    {
        Usuario usuario1;
        Conexao con;

        public FrmUsuario()
        {
            InitializeComponent();
            con = new Conexao();
            usuario1 = new Usuario();
        }
        
        public void bloquearCampos()
        {
            txtID.ReadOnly = true;
            txtNome.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtSenha.ReadOnly = true;
            txtUsuario.ReadOnly = true;
            cbStatus.Enabled = false;
        }

        public void desbloquearCampos()
        {
            txtID.ReadOnly = false;
            txtNome.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtSenha.ReadOnly = false;
            txtUsuario.ReadOnly = false;
            cbStatus.Enabled = true;
        }

        private void lerDados()
        {
            usuario1.id = int.Parse(txtID.ToString().Trim());
            usuario1.nome = txtNome.Text;
            usuario1.email = txtEmail.Text;
            usuario1.senha = txtSenha.Text;
            usuario1.usuario = txtUsuario.Text;
            usuario1.status = Boolean.Parse(cbStatus.ToString().Trim());
            usuario1.id_perfil = int.Parse(txtID.ToString().Trim());
        }

        public void bloquearBotoes()
        {
            btnSalvar.Enabled = false;
            btnSair.Enabled = false;
            btnNovo.Enabled = false;
            btnCancelar.Enabled = false;
        }

        public void desbloquearBotoes()
        {
            btnCancelar.Enabled = true;
            btnNovo.Enabled = true;
            btnSair.Enabled = true;
            btnSalvar.Enabled = true;
       }

        public void limparDados()
        {
            txtID.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtUsuario.Text = "";
            cbStatus.Text = "";
            cbPerfil.Text = "";
        }

        private void comboStatus()
        {
            List<Perfil> listPerfil = new List<Perfil>();
            con.OpenConnection();
            MySqlDataReader reader;
            reader = con.executeQuery("select * from tb_perfil");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Perfil perfil = new Perfil();
                    perfil.id = reader.GetInt32(0);
                    perfil.nome = reader.GetString(1);
                    perfil.cad_usuario = reader.GetBoolean(2);
                    perfil.cad_perfil = reader.GetBoolean(3);
                    perfil.cad_setor = reader.GetBoolean(4);
                    perfil.cad_funcionario = reader.GetBoolean(5);
                    perfil.rel_setor = reader.GetBoolean(6);
                    perfil.rel_funcionario = reader.GetBoolean(7);
                    perfil.status = reader.GetBoolean(8);

                    listPerfil.Add(perfil);
                }
                reader.Close();
                reader.Dispose();
            }
            else
                {
                Console.WriteLine("Não retornou dados");
            }
            cbPerfil.DataSource = null;
            cbPerfil.DataSource = listPerfil;
            cbPerfil.DisplayMember = "nome";
            cbPerfil.ValueMember = "id";
        }

       public void atualizarGrid()
        {
            List<Usuario> listUsuario = new List<Usuario>();
            con.OpenConnection();
            MySqlDataReader reader;
            reader = con.executeQuery("select * from tb_usuario");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Usuario usuario1 = new Usuario();
                    usuario1.id = reader.GetInt32(0);
                    usuario1.nome = reader.GetString(1);
                    usuario1.email = reader.GetString(2);
                    usuario1.senha = reader.GetString(3);
                    usuario1.usuario = reader.GetString(4);
                    usuario1.status = reader.GetBoolean(5);
                    usuario1.id_perfil = reader.GetInt32(6);

                    listUsuario.Add(usuario1);
                }
                reader.Close();
                reader.Dispose();
            }
            else
            {
                Console.WriteLine("Não retornou dados.");
            }

            dgvusuario.DataSource = null;
            dgvusuario.DataSource = listUsuario;

        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            bloquearCampos();
            comboStatus();
            atualizarGrid();
      
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            desbloquearCampos();
            limparDados();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja cancelar?","Cancelar",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Yes);
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
         
        }

        private void FrmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
