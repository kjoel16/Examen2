using Entidades;
using Informacion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Examen2
{
    public partial class TicketsForm : Form
    {
   
        public TicketsForm()
        {
            InitializeComponent();
            LlenarComboBoxUsuarios();
 
        }
        string operacion;
        Ticket ticket;
        TicketDB ticketDB = new TicketDB();
        Cliente cliente;
        ClienteDB clienteDb = new ClienteDB();
        Usuarios usuarios;
        UsuariosDB usuariosDB = new UsuariosDB();


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

        private void Salirbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            LlenarComboBoxUsuarios();
            operacion = "Nuevo";
            ticket = new Ticket();
            cliente = new Cliente();
            usuarios = new Usuarios();
            cliente.Nombre = ClientetextBox.Text;
            cliente.idclientes = IdentidadtextBox.Text;
            usuarios.Nombre = UsuarioscomboBox.Text;
            ticket.IdentidadClientes = IdentidadtextBox.Text;
            ticket.Usuarios = UsuarioscomboBox.Text;
            ticket.TipoSoporte = TipoSoportecomboBox.Text;
            //ticket.IdentidadClientes = IdentidadtextBox.Text;
            ticket.DescripcionSolicitud = SolicitudtextBox2.Text;
            ticket.DescripcionRespuesta = RespuestatextBox.Text;
            ticket.Precio = Convert.ToDecimal(PreciotextBox.Text);
            ticket.Impuesto = Convert.ToDecimal(ImpuestotextBox.Text);
            ticket.Descuento = Convert.ToDecimal(DescuentotextBox.Text);
            if (operacion == "Nuevo")
            {
               

                if (string.IsNullOrEmpty(ClientetextBox.Text))
                {
                    errorProvider1.SetError(ClientetextBox, "Ingrese una descripción");
                    ClientetextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(PreciotextBox.Text))
                {
                    errorProvider1.SetError(PreciotextBox, "Ingrese un precio");
                    PreciotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                bool inserto2 = clienteDb.Insertar(cliente);
                bool inserto = ticketDB.Insertar(ticket);
               // bool inserto2 = clienteDb.Insertar(cliente);
                //bool inserto3 = usuariosDB.Insertar(ticket);
                if (inserto)
                {                  
                    MessageBox.Show("Registro guardado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
            

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
      
        }
    }
}
