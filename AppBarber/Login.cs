using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBarber
{
    public partial class Login : Form
    {
        dbConnection con = new dbConnection();
        
        public Login()
        {
            InitializeComponent();


        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
            txtPass.MaxLength = 14;
 
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
            txtPass.Text = "";
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                if(txtLogin.Text != "" && txtPass.Text != "")
                {
                    if (con.validaLogin(txtLogin.Text, txtPass.Text))
                    {
                        this.Hide();
                        Menu c1 = new Menu();
                        c1.ShowDialog();

                    }
                    else
                    {

                        MessageBox.Show("USER OU SENHA INCORRETA", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLogin.Text = "";
                        txtPass.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("USER OU SENHA EM BRANCO","AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
            }
            catch (Exception er)
            {
                MessageBox.Show($"ERRO= {er}");
            }

        }

        private void TxtLogin_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pressEnter(object sender, KeyEventArgs e)
        {
        }
           


    }
}
