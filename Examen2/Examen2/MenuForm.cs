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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void Salirbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Ticketsbutton_Click(object sender, EventArgs e)
        {
            TicketsForm ticketFormulario = new TicketsForm();
            Hide();
            ticketFormulario.Show();
        }
    }
}
