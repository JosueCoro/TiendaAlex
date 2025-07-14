using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Rol
    {
        //Lista todos los roles
        public List<Rol> ListarRoles()
        {
            List<Rol> lista = new List<Rol>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("administracion.crud_roles", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Operacion", "SELECT");

                    SqlParameter paramMensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter paramNuevoIdRol = new SqlParameter("@NuevoIdRol", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramMensaje);
                    cmd.Parameters.Add(paramResultado);
                    cmd.Parameters.Add(paramNuevoIdRol);

                    conexion.Open();


                    SqlDataReader lectura = cmd.ExecuteReader();
                    while (lectura.Read())
                    {
                        lista.Add(new Rol()
                        {
                            id_rol = Convert.ToInt32(lectura["id_rol"]),
                            nombre = lectura["nombre"].ToString(),
                            estado = Convert.ToBoolean(lectura["estado"])
                        });
                    }
                }


            }
            catch
            {
                lista = new List<Rol>();
            }
            return lista;
        }

        public int Registrar(Rol rol, out string mensaje)
        {
            int id_autogenerado = 0;
            int resultado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("administracion.crud_roles ", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", "INSERT");

                    cmd.Parameters.AddWithValue("@Nombre", rol.nombre);
                    cmd.Parameters.AddWithValue("@Estado", rol.estado);
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@NuevoIdRol", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conexion.Open();

                    //cmd.ExecuteNonQuery();
                    //mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    //resultado = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);
                    //id_autogenerado = Convert.ToInt32(cmd.Parameters["@NuevoIdRol"].Value);
                    cmd.ExecuteNonQuery();

                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    resultado = cmd.Parameters["@Resultado"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@Resultado"].Value) : 0;
                    id_autogenerado = cmd.Parameters["@NuevoIdRol"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@NuevoIdRol"].Value) : 0;

                }
            }
            catch (Exception ex)
            {
                id_autogenerado = 0;
                mensaje = ex.Message;
            }
            return id_autogenerado;
        }

        public bool Editar(Rol rol, out string mensaje)
        {
            bool resultado = false;
            int id_autogenerado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("administracion.crud_roles", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", "UPDATE");
                    cmd.Parameters.AddWithValue("@IdRol", rol.id_rol);
                    cmd.Parameters.AddWithValue("@Nombre", rol.nombre);
                    cmd.Parameters.AddWithValue("@Estado", rol.estado);
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@NuevoIdRol", SqlDbType.Int).Direction = ParameterDirection.Output;
                    conexion.Open();

                    //cmd.ExecuteNonQuery();
                    //mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    //resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    //id_autogenerado = Convert.ToInt32(cmd.Parameters["@NuevoIdRol"].Value);
                    cmd.ExecuteNonQuery();

                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    //resultado = cmd.Parameters["@Resultado"].Value != DBNull.Value ? Convert.ToBoolean(cmd.Parameters["@Resultado"].Value) : false;
                    id_autogenerado = cmd.Parameters["@NuevoIdRol"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@NuevoIdRol"].Value) : 0;

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int id_rol, out string mensaje)
        {
            bool resultado = false;
            int id_autogenerado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("administracion.crud_roles", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", "DELETE");
                    cmd.Parameters.AddWithValue("@Nombre", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdRol", id_rol);

                    SqlParameter pMensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter pResultado = new SqlParameter("@Resultado", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter pNuevoIdRol = new SqlParameter("@NuevoIdRol", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(pMensaje);
                    cmd.Parameters.Add(pResultado);
                    cmd.Parameters.Add(pNuevoIdRol);

                    conexion.Open();

                    //cmd.ExecuteNonQuery();

                    ////mostrar mensaje
                    //mensaje = cmd.Parameters["@Mensaje"].Value.ToString();

                    //resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    //id_autogenerado = Convert.ToInt32(cmd.Parameters["@NuevoIdRol"].Value);
                    cmd.ExecuteNonQuery();

                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();

                    resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    id_autogenerado = cmd.Parameters["@NuevoIdRol"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@NuevoIdRol"].Value) : 0;

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return resultado;
        }
    }
}
