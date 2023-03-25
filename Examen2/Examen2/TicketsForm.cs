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

        }
        private void LlenarComboBoxUsuarios()
        {
            UsuariosDB dt = new UsuariosDB();
            List<string> usuarios = dt.DevolverUsuarios();
            UsuarioscomboBox.DataSource = usuarios;
            UsuarioscomboBox.Refresh();
        }
        private void RegistrarCliente()
        {
            cliente = new Cliente();
            cliente.idclientes = IdentidadtextBox.Text;
            cliente.Nombre = ClientetextBox.Text;
            bool inserto1 = clienteDb.Insertar(cliente);
            if (inserto1)
            {
                MessageBox.Show("Registro guardado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el registro", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Salirbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            RegistrarCliente();
            ticket = new Ticket();
            cliente = new Cliente();
            usuarios = new Usuarios();
            usuarios.Idusuarios = UsuarioscomboBox.Text;
            string idusuarios = usuarios.Idusuarios;
            cliente.idclientes = IdentidadtextBox.Text; 
            string idCliente = cliente.idclientes;
            ticket.Fecha = FechadateTimePicker.Value;
            ticket.IdentidadClientes = idCliente;
            ticket.TipoSoporte = TipoSoportecomboBox.Text;
            ticket.DescripcionSolicitud = SolicitudtextBox2.Text;
            ticket.DescripcionRespuesta = RespuestatextBox.Text;
            ticket.Precio = Convert.ToDecimal(PreciotextBox.Text);
            ticket.Impuesto = Convert.ToDecimal(ImpuestotextBox.Text);
            ticket.Descuento = Convert.ToDecimal(DescuentotextBox.Text);
            ticket.Idusuarios = idusuarios;
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
                
                bool inserto = ticketDB.Insertar(ticket);
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

       
    }
}
