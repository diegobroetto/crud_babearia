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
    public partial class Menu : Form
    {

        Usuarios user = new Usuarios();
        public Menu()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void UsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user.ShowDialog();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
         
        }
    }
}
