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
    public class UsuariosDB
    {
        string cadena = "server=localhost; user=root; database=examen2; password=123456;";

        public Usuarios Autenticar(Login login)
        {
            Usuarios user = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM usuarios WHERE Idusuarios = @Idusuarios AND Contrasena = @Contrasena;");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Idusuarios", MySqlDbType.VarChar, 50).Value = login.Idusuarios;
                        comando.Parameters.Add("@Contrasena", MySqlDbType.VarChar, 50).Value = login.Contraseña;

                        MySqlDataReader dr = comando.ExecuteReader();
                        if (dr.Read())
                        {
                            user = new Usuarios();

                            user.Idusuarios = dr["Idusuarios"].ToString();
                            user.Nombre = dr["Nombre"].ToString();
                            user.Contraseña = dr["Contrasena"].ToString();
                            user.Correo = dr["Correo"].ToString();
                            
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return user;
        }
        public List<string> DevolverUsuarios()
        {
            List<string> usuarios = new List<string>();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT Idusuarios FROM usuarios");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        using (MySqlDataReader dr = comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                usuarios.Add(dr.GetString("Idusuarios"));
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return usuarios;
        }


    }
}

