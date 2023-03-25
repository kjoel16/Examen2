using Entidades;
using Informacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (UsuarioTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese un usuario");
                UsuarioTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(ContraseñaTextBox.Text))
            {
                errorProvider1.SetError(ContraseñaTextBox, "Ingrese una contraseña");
                ContraseñaTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            //Validar en la base de datos
            Login login = new Login(UsuarioTextBox.Text, ContraseñaTextBox.Text);
            Usuarios usuarios = new Usuarios();
            UsuariosDB usuarioDB = new UsuariosDB();
            usuarios = usuarioDB.Autenticar(login);
            if (usuarios != null)
            {
                MenuForm menuFormulario = new MenuForm();
                Hide();
                menuFormulario.Show();
            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void MostrarContraseñaButton_Click(object sender, EventArgs e)
        {
            if (ContraseñaTextBox.PasswordChar == '*')
            {
                ContraseñaTextBox.PasswordChar = '\0';
            }
            else
            {
                ContraseñaTextBox.PasswordChar = '*';
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UsuarioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
