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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Examen2
{
    public partial class TicketsForm : Form
    {
        public TicketsForm()
        {
            InitializeComponent();
            LlenarComboBoxUsuarios();
        }


        private void UsuarioscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboBoxUsuarios();
        }
        private void LlenarComboBoxUsuarios()
        {
            UsuariosDB dt = new UsuariosDB();
            List<string> usuarios = dt.DevolverUsuarios();
            UsuarioscomboBox.DataSource = usuarios;
            UsuarioscomboBox.Refresh();
        }
    }
}
