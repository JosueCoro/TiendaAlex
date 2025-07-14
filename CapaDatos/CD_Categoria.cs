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
    public class CD_Categoria
    {
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("comercio.crud_caregoria", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetro de operación para SELECT
                    cmd.Parameters.AddWithValue("@Operacion", "SELECT");

                    // Definición de parámetros de salida (aunque no se leen explícitamente para SELECT)
                    SqlParameter paramMensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter paramNuevoId = new SqlParameter("@NuevoId", SqlDbType.Int) // Nombre de parámetro según SP
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramMensaje);
                    cmd.Parameters.Add(paramResultado);
                    cmd.Parameters.Add(paramNuevoId); // Añadir el parámetro de salida

                    conexion.Open();

                    SqlDataReader lectura = cmd.ExecuteReader();
                    while (lectura.Read())
                    {
                        lista.Add(new Categoria()
                        {
                            id_categoria = Convert.ToInt32(lectura["id_categoria"]),
                            nombre = lectura["nombre"].ToString(),
                            estado = Convert.ToBoolean(lectura["estado"])
                        });
                    }
                    // Cierra el lector una vez que termina de leer
                    lectura.Close();
                }
            }
            catch (Exception ex)
            {
                // En caso de error, la lista se inicializa vacía
                lista = new List<Categoria>();
                // Puedes loggear el error aquí: Console.WriteLine(ex.Message);
            }
            return lista;
        }

        // Método para registrar una nueva categoría
        public int Registrar(Categoria categoria, out string mensaje)
        {
            int id_autogenerado = 0;
            // 'resultado' se usará para verificar si la operación fue exitosa según el SP
            int resultadoSP = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("comercio.crud_caregoria", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada para INSERT
                    cmd.Parameters.AddWithValue("@Operacion", "INSERT");
                    cmd.Parameters.AddWithValue("@Nombre", categoria.nombre);
                    cmd.Parameters.AddWithValue("@Estado", categoria.estado);

                    // Parámetros de salida
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@NuevoId", SqlDbType.Int).Direction = ParameterDirection.Output; // Nombre de parámetro según SP

                    conexion.Open();
                    cmd.ExecuteNonQuery(); // Ejecuta el comando

                    // Recupera los valores de los parámetros de salida
                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    // Conversión segura de resultado y nuevo ID
                    resultadoSP = cmd.Parameters["@Resultado"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@Resultado"].Value) : 0;
                    // CORRECCIÓN: Usar "@NuevoId" en lugar de "@NuevoIdRol"
                    id_autogenerado = cmd.Parameters["@NuevoId"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@NuevoId"].Value) : 0;
                }
            }
            catch (Exception ex)
            {
                id_autogenerado = 0;
                mensaje = ex.Message; // Captura el mensaje de la excepción
            }
            return id_autogenerado;
        }

        // Método para editar una categoría existente
        public bool Editar(Categoria categoria, out string mensaje)
        {
            bool resultado = false;
            // 'id_autogenerado' no es relevante para editar, pero se mantiene por consistencia con el patrón
            int id_autogenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("comercio.crud_caregoria", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada para UPDATE
                    cmd.Parameters.AddWithValue("@Operacion", "UPDATE");
                    cmd.Parameters.AddWithValue("@IdCategoria", categoria.id_categoria); // ID de la categoría a editar
                    cmd.Parameters.AddWithValue("@Nombre", categoria.nombre);
                    cmd.Parameters.AddWithValue("@Estado", categoria.estado);

                    // Parámetros de salida
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@NuevoId", SqlDbType.Int).Direction = ParameterDirection.Output; // Nombre de parámetro según SP

                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    // Recupera los valores de los parámetros de salida
                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    // CORRECCIÓN: Usar "@NuevoId" en lugar de "@NuevoIdRol"
                    id_autogenerado = cmd.Parameters["@NuevoId"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@NuevoId"].Value) : 0;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message; // Captura el mensaje de la excepción
            }
            return resultado;
        }

        // Método para eliminar una categoría
        public bool Eliminar(int id_categoria, out string mensaje)
        {
            bool resultado = false;
            // 'id_autogenerado' no es relevante para eliminar, pero se mantiene por consistencia
            int id_autogenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("comercio.crud_caregoria", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada para DELETE
                    cmd.Parameters.AddWithValue("@Operacion", "DELETE");
                    cmd.Parameters.AddWithValue("@IdCategoria", id_categoria); // ID de la categoría a eliminar
                    // Los parámetros de nombre y estado no son necesarios para DELETE, se envían como DBNull.Value
                    cmd.Parameters.AddWithValue("@Nombre", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", DBNull.Value);

                    // Parámetros de salida
                    SqlParameter paramMensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter paramNuevoId = new SqlParameter("@NuevoId", SqlDbType.Int) // Nombre de parámetro según SP
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramMensaje);
                    cmd.Parameters.Add(paramResultado);
                    cmd.Parameters.Add(paramNuevoId); // Añadir el parámetro de salida

                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    // Recupera los valores de los parámetros de salida
                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    // CORRECCIÓN: Usar "@NuevoId" en lugar de "@NuevoIdRol"
                    id_autogenerado = cmd.Parameters["@NuevoId"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@NuevoId"].Value) : 0;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message; // Captura el mensaje de la excepción
            }
            return resultado;
        }
    }
}
