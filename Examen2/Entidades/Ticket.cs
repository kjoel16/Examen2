using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ticket
    {
        public int idticket { get; set; }
        public DateTime Fecha { get; set; }
        public string IdentidadClientes { get; set; }
        public string Idusuarios { get; set; }
        public string TipoSoporte { get; set; }
        public string DescripcionSolicitud { get; set; }
        public string DescripcionRespuesta { get; set; }
        public decimal Precio { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        public Ticket()
        {
        }

        public Ticket(int idticket, DateTime fecha, string identidadClientes, string idusuarios, string tipoSoporte, string descripcionSolicitud, string descripcionRespuesta, decimal precio, decimal impuesto, decimal descuento, decimal total)
        {
            this.idticket = idticket;
            Fecha = fecha;
            IdentidadClientes = identidadClientes;
            Idusuarios = idusuarios;
            TipoSoporte = tipoSoporte;
            DescripcionSolicitud = descripcionSolicitud;
            DescripcionRespuesta = descripcionRespuesta;
            Precio = precio;
            Impuesto = impuesto;
            Descuento = descuento;
            Total = total;
        }
    }
    
}
