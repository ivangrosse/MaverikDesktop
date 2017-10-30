using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaverikDesktop.Views
{
    public partial class Login : Form
    {
        int contadorUsuario = 0;
        int contadorContraseña = 0;

        public Login()
        {
            InitializeComponent();
        }

        private void nombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerarRutas generarRutas = new GenerarRutas();
            this.Hide();
            generarRutas.Show();

        }

        private void contraseñaUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombreUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            if (contadorUsuario < 1)
            {
                nombreUsuario.Text = "";
            }
            contadorUsuario += 1;
            

        }

        private void contraseñaUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            if (contadorContraseña < 1)
            {
                contraseñaUsuario.Text = "";
            }
            contadorContraseña += 1;
            contraseñaUsuario.UseSystemPasswordChar = true;
        }
    }
}