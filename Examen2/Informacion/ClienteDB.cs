using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informacion
{
    public class ClienteDB
    {
        string cadena = "server=localhost; user=root; database=examen2; password=123456;";
        public bool Insertar(Cliente cliente)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO clientes VALUES ");
                sql.Append(" (@idclientes, @Nombre, @Correo; ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 25).Value = cliente.idclientes;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 50).Value = cliente.Nombre;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 45).Value = cliente.Correo;
                        comando.ExecuteNonQuery();
                        inserto = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return inserto;
        }
    }
}
