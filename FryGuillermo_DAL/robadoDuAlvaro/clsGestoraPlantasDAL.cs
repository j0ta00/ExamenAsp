using _07_CRUD_Personas_DAL.Conexion;
using FryGuillermo2_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoExamen_DAL.Plantas
{
    public class clsGestoraPlantasDAL
    {
        #region propiedades privadas
        static clsMyConnection connector;
        #endregion
        #region constructor
        public clsGestoraPlantasDAL()
        {
            connector = new clsMyConnection();
        }
        #endregion
        #region metodos aux
        private static SqlCommand SqlCommandCParametros(clsPlanta planta)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@nombrePlanta", planta.NombrePlanta);
            comando.Parameters.AddWithValue("@descripcion", planta.DescripcionPlanta);
            comando.Parameters.AddWithValue("@idCategoria", planta.IdCategoria);
            double precioAsignado = (planta.Precio >= 0) ? planta.Precio : 0;
            comando.Parameters.AddWithValue("@precio", precioAsignado);
            return comando;
        }
        #endregion
        #region insertar
        /// <summary>
        /// Metodo que inserta en la base de datos una planta con los datos de la planta recibida por parametro
        /// </summary>
        /// <param name="planta"></param>
        /// <returns>int filasAfectadas</returns>
        public static int InsertPlanta(clsPlanta planta)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando= SqlCommandCParametros(planta);
            comando.CommandText = "INSERT INTO Plantas VALUES (@nombrePlanta, @descripcion,@idCategoria,@precio)";
            comando.Connection = sqlConnection;
            int filasAfectadas=comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
            return filasAfectadas;
        }
        #endregion
        #region update
        /// <summary>
        /// Metodo que actualiza los datos de la planta en la bdd cuyo id coincide con el de la planta recibida por parametro y le establece sus datos
        /// </summary>
        /// <param name="planta"></param>
        /// <returns>int filasAfectadas</returns>
        public static int UpdatePlanta(int idPlanta, clsPlanta planta) 
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = SqlCommandCParametros(planta);
            comando.Parameters.AddWithValue("@idPlanta", idPlanta);
            comando.CommandText = "UPDATE plantas SET nombrePlanta=@nombrePlanta, descripcion=@descripcion ,idCategoria=@idCategoria, precio=@precio WHERE (idPlanta=@idPlanta)";
            comando.Connection = sqlConnection;
            int filasAfectadas = comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
            return filasAfectadas;
        }
        #endregion
        #region delete
        /// <summary>
        /// Metodo que ejecuta una instruccion delete para borrar la planta con el id especificado en la BDD
        /// </summary>
        /// <param name="idPlanta"></param>
        /// <returns>int filasAfectadas</returns>
        public static int DeletePlanta(int idPlanta)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@idPlanta", idPlanta);
            comando.CommandText = "DELETE FROM Plantas WHERE (idPlanta=@idPlanta)";
            comando.Connection = sqlConnection;
            int filasAfectadas = comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
            return filasAfectadas;
        }
        #endregion
        #region Alterar datos
        /// <summary>
        /// Establece el precio de la planta con el id recibido a el float que se le especifica por parametro
        /// </summary>
        /// <param name="idPlanta"></param>
        /// <param name="precio"></param>
        public static int CambiarPrecio(int idPlanta, double precio) 
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@idPlanta", idPlanta);
            double precioAsignado = (precio >= 0) ? precio : 0;
            comando.Parameters.AddWithValue("@precio", precioAsignado);
            comando.CommandText = "UPDATE plantas SET precio=@precio WHERE (idPlanta=@idPlanta)";
            comando.Connection = sqlConnection;
            int filasAfectadas = comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
            return filasAfectadas;
        }
        #endregion
    }
}
