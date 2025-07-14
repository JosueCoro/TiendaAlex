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
    public class CD_Marca
    {
        /*
--PA crud de marca
CREATE PROCEDURE comercio.crud_marca 
    @Operacion NVARCHAR(10),
    @IdMarca INT = NULL,
    @Nombre VARCHAR(150) = NULL,
    @Estado BIT = NULL,
    @NuevoId INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT,
    @Resultado BIT OUTPUT
AS
BEGIN
    SET @Resultado = 0;
    SET @NuevoId = NULL;

    -- INSERTAR NUEVA MARCA
    IF @Operacion = 'INSERT'
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM comercio.marca   WHERE nombre = @Nombre)
        BEGIN
            INSERT INTO comercio.marca   (nombre, estado)
            VALUES (@Nombre, ISNULL(@Estado, 1));

            SET @NuevoId = SCOPE_IDENTITY();
            SET @Resultado = 1;
            SET @Mensaje = 'Marca registrada correctamente.';
        END
        ELSE
            SET @Mensaje = 'Ya existe una Marca con ese nombre.';
    END

    -- CONSULTAR Marcas
    ELSE IF @Operacion = 'SELECT'
    BEGIN
        SELECT * FROM comercio.marca;
        SET @Resultado = 1;
    END

    -- ACTUALIZAR ROL
    ELSE IF @Operacion = 'UPDATE'
    BEGIN
        IF NOT EXISTS (
            SELECT 1 
            FROM comercio.marca   
            WHERE nombre = @Nombre AND id_marca != @IdMarca
        )
        BEGIN
            UPDATE comercio.marca  
            SET nombre = @Nombre,
                estado = @Estado
            WHERE id_marca = @IdMarca;

            SET @Resultado = 1;
			SET @NuevoId = @IdMarca;
            SET @Mensaje = 'Marca actualizada correctamente.';
        END
        ELSE
            SET @Mensaje = 'Ya existe otra Marca con ese nombre.';
    END

    -- ELIMINAR ROL
    ELSE IF @Operacion = 'DELETE'
    BEGIN
        IF NOT EXISTS (
            SELECT 1 
            FROM comercio.prenda  
            WHERE marca_id_marca = @IdMarca
        )
        BEGIN
            DELETE FROM comercio.marca  
            WHERE id_marca = @IdMarca;

            SET @Resultado = 1;
			SET @NuevoId = @IdMarca;
            SET @Mensaje = 'Marca eliminada correctamente.';
        END
        ELSE
            SET @Mensaje = 'La Marca está relacionado con una o mas prendas. No se puede eliminar.';
    END

    -- OPERACIÓN INVÁLIDA
    ELSE
    BEGIN
        SET @Mensaje = 'Operación no válida.';
    END
END
GO*/

        //Listar marcas
        public List<Marca> ListarMarcas()
        {
            List<Marca> lista = new List<Marca>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("comercio.crud_marca", conexion);
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
                    SqlParameter paramNuevoIdRol = new SqlParameter("@NuevoId", SqlDbType.Int)
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
                        lista.Add(new Marca()
                        {
                            id_marca = Convert.ToInt32(lectura["id_marca"]),
                            nombre = lectura["nombre"].ToString(),
                            estado = Convert.ToBoolean(lectura["estado"])
                        });
                    }
                    
                }
            }
            catch (Exception ex)
            {
                lista = new List<Marca>();
            }
            return lista;

        }

        //Registrar marca
        public int Registrar(Marca marca, out string mensaje)
        {
            int id_autogenerado = 0;
            int resultado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("comercio.crud_marca", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", "INSERT");
                    cmd.Parameters.AddWithValue("@Nombre", marca.nombre);
                    cmd.Parameters.AddWithValue("@Estado", marca.estado);

                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@NuevoId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    resultado = cmd.Parameters["@Resultado"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@Resultado"].Value) : 0;
                    id_autogenerado = cmd.Parameters["@NuevoId"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@NuevoId"].Value) : 0;
                }
            }
            catch (Exception ex)
            {
                id_autogenerado = 0;
                mensaje = ex.Message;       
            }
            return id_autogenerado;
        }

        //Editar marca
        public bool Editar(Marca marca, out string mensaje)
        {
            bool resultado = false;
            int id_autogenerado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("comercio.crud_marca", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", "UPDATE");
                    cmd.Parameters.AddWithValue("@IdMarca", marca.id_marca);
                    cmd.Parameters.AddWithValue("@Nombre", marca.nombre);
                    cmd.Parameters.AddWithValue("@Estado", marca.estado);
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@NuevoId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    

                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    id_autogenerado = cmd.Parameters["@NuevoId"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@NuevoId"].Value) : 0;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;            
            }
            return resultado;
        }

        //Eliminar marca

        public bool Eliminar(int id_marca, out string mensaje)
        {
            bool resultado = false;
            int id_autogenerado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("comercio.crud_marca", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", "DELETE");
                    cmd.Parameters.AddWithValue("@Nombre", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Estado", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdMarca", id_marca);
                    SqlParameter paramMensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter paramNuevoId = new SqlParameter("@NuevoId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(paramMensaje);
                    cmd.Parameters.Add(paramResultado);
                    cmd.Parameters.Add(paramNuevoId);
                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    id_autogenerado = cmd.Parameters["@NuevoId"].Value != DBNull.Value ? Convert.ToInt32(cmd.Parameters["@NuevoIdRol"].Value) : 0;

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
