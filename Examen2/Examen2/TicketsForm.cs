using Entidades;
using Informacion;
using System;
using System.Collections.Generic;
using System.Linq;
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
        decimal Total = 0;
        decimal Impuesto = 0;
        decimal Precio = 0;
        decimal descuento = 0;


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
       
        private void Salirbutton_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            
            
            operacion = "Nuevo";
            
            ticket = new Ticket();
            List<int> numeros = Enumerable.Range(1, 500).OrderBy(x => Guid.NewGuid()).ToList();
            int numeroAleatorio = numeros[0];
            cliente = new Cliente();
            usuarios = new Usuarios();
            usuarios.Idusuarios = UsuarioscomboBox.Text;
            string idusuarios = usuarios.Idusuarios;
            cliente.idclientes = IdentidadtextBox.Text; 
            string idCliente = cliente.idclientes;
            ticket.idticket = numeroAleatorio;
            ticket.Fecha = FechadateTimePicker.Value;
            ticket.IdentidadClientes = idCliente;
            ticket.TipoSoporte = TipoSoportecomboBox.Text;
            ticket.DescripcionSolicitud = SolicitudtextBox2.Text;
            ticket.DescripcionRespuesta = RespuestatextBox.Text;
            
            
            if (operacion == "Nuevo")
            {
               

                if (string.IsNullOrEmpty(ClientetextBox.Text))
                {
                    errorProvider1.SetError(ClientetextBox, "Ingrese el Nombre del cliente");
                    ClientetextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(IdentidadtextBox.Text))
                {
                    errorProvider1.SetError(IdentidadtextBox, "Ingrese la identidad del cliente");
                    IdentidadtextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(TipoSoportecomboBox.Text))
                {
                    errorProvider1.SetError(TipoSoportecomboBox, "Seleccione un tipo de soporte");
                    TipoSoportecomboBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(SolicitudtextBox2.Text))
                {
                    errorProvider1.SetError(SolicitudtextBox2, "Ingrese la Solicitud");
                    SolicitudtextBox2.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(RespuestatextBox.Text))
                {
                    errorProvider1.SetError(RespuestatextBox, "Ingrese su respuesta");
                    RespuestatextBox.Focus();
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
                if (string.IsNullOrEmpty(DescuentotextBox.Text))
                {
                    errorProvider1.SetError(DescuentotextBox, "Ingrese un descuento");
                    DescuentotextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                Precio = Convert.ToDecimal(PreciotextBox.Text);
                Impuesto = Precio * 15 / 100;
                descuento = Convert.ToDecimal(DescuentotextBox.Text);
                Total = Precio + Impuesto - descuento;
                ticket.Precio = Precio;
                ticket.Descuento = descuento;
                ticket.Impuesto = Impuesto;
                ticket.Total = Total;
                ticket.Idusuarios = idusuarios;
                RegistrarCliente();

                bool inserto = ticketDB.Insertar(ticket);
                if (inserto)
                {                  
                    MessageBox.Show("ticket ingresado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar el ticket", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
           
            

        }
        private void RegistrarCliente()
        {
            cliente = new Cliente();
            cliente.idclientes = IdentidadtextBox.Text;
            cliente.Nombre = ClientetextBox.Text;
            bool inserto1 = clienteDb.Insertar(cliente);
            if (inserto1)
            {
                MessageBox.Show("Cliente registrado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo registrar el cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PreciotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar != '.' && (sender as TextBox).Text.IndexOf('.') > -1 && (sender as TextBox).Text.Split('.')[1].Length == 2)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }


        }

        private void DescuentotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar != '.' && (sender as TextBox).Text.IndexOf('.') > -1 && (sender as TextBox).Text.Split('.')[1].Length == 2)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void IdentidadtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ClientetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }

        private void SolicitudtextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }

        private void RespuestatextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
