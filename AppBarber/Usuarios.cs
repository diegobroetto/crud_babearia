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

namespace AppBarber
{
    public partial class Usuarios : Form
    {
        dbConnection con = new dbConnection();
        public Usuarios()
        {
            InitializeComponent();
            initGrid(con.getUsers());
        }

        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            
            txtIdUser.Enabled = false;
            txtLogin.Enabled = false;
            txtNomeUser.Enabled = false;
            txtPass.Enabled = false;

        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            txtIdUser.Enabled = false;
            txtLogin.Enabled = true;
            txtNomeUser.Enabled = true;
            txtPass.Enabled = true;
            txtNomeUser.Text = "";
            txtPass.Text = "";
            txtLogin.Text = "";
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            txtIdUser.Enabled = false;
            txtLogin.Enabled = true;
            txtNomeUser.Enabled = true;
            txtPass.Enabled = true;
            
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            
            if (con.inserirUser(txtNomeUser.Text, txtLogin.Text, txtPass.Text))
            {
                MessageBox.Show("INSERIDO COM SUCESSO");
            }
            else
            {
                MessageBox.Show("FALHA AO INSERIR");
            }
        }
        private void initGrid(DataTable data)
        {
            
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["senha"].Visible = false;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdUser.Text = dataGridView1.CurrentRow.Cells["idusuario"].Value.ToString();
            txtLogin.Text = dataGridView1.CurrentRow.Cells["user"].Value.ToString();
            txtNomeUser.Text = dataGridView1.CurrentRow.Cells["nome"].Value.ToString();
            txtPass.PasswordChar = '*';
            txtPass.Text = dataGridView1.CurrentRow.Cells["senha"].Value.ToString();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void BtnPesquisa_Click(object sender, EventArgs e)
        {
            initGrid(con.consultaUser(cbPesquisa.Text, txtPesquisa.Text));

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja excluir usuário? ", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                con.deletaUser(txtIdUser.Text);
                MessageBox.Show("Excluído Com Sucesso!");
            }
 
        }

        private void BtnCancela_Click(object sender, EventArgs e)
        {
            txtIdUser.Enabled = false;
            txtLogin.Enabled = false;
            txtNomeUser.Enabled = false;
            txtPass.Enabled = false;

        }
    }
}
