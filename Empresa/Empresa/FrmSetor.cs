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
    public partial class Setor : Form
    {
        Setor1 setor1;
        Conexao con;

        public Setor()
        {
            InitializeComponent();
            con = new Conexao();
            setor1 = new Setor1();
        }
        
        public void bloquearCampos()
        {
            txtIdSetor.ReadOnly = true;
            txtNome.ReadOnly = true;
            cbStatus.Enabled = false;
        }

        public void desbloquearCampos()
        {
            txtIdSetor.ReadOnly = false;
            txtNome.ReadOnly = false;
            cbStatus.Enabled = true;
        }

        private void lerDados()
        {
            setor1.ID = int.Parse(txtID.ToString().Trim());
            setor1.nome = txtNome.Text;
            setor1.status = Boolean.Parse(cbStatus.ToString().Trim());
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
            cbStatus.Text = "";
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
            cbStatus.DataSource = null;
            cbStatus.DataSource = listPerfil;
            cbStatus.DisplayMember = "nome";
            cbStatus.ValueMember = "ID";
        }

        public void atualizarGrid()
        {
            List<Setor1> listSetor = new List<Setor1>();
            con.OpenConnection();
            MySqlDataReader reader;
            reader = con.executeQuery("select * from tb_setor");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Setor1 setor1 = new Setor1();
                    setor1.ID = reader.GetInt32(0);
                    setor1.nome = reader.GetString(1);
                    setor1.status = reader.GetBoolean(2);

                    listSetor.Add(setor1);
                }
                reader.Close();
                reader.Dispose();
            }
            else
            {
                Console.WriteLine("Não retornou dados.");
            }

            dgvSetor.DataSource = null;
            dgvSetor.DataSource = listSetor;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            desbloquearCampos();
            limparDados();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja cancelar?", "Cancelar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Yes) ;
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }

        private void Setor_Load(object sender, EventArgs e)
        {
            bloquearCampos();
            comboStatus();
            atualizarGrid();
        }

        private void Setor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
