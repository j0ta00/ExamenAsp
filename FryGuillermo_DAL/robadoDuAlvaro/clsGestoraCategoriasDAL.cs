using _07_CRUD_Personas_DAL.Conexion;
using FryGuillermo2_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Proyecto_Examen_DAL.Categorias
{
    public class clsGestoraCategoriasDAL
    {
        static clsMyConnection connection;
        public clsGestoraCategoriasDAL(){
            connection = new clsMyConnection();
        }
        #region metodos aux
        private static SqlCommand SqlCommandCParametros(clsCategoria categoria)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@id", categoria.IdCategoria);
            comando.Parameters.AddWithValue("@nombre", categoria.nombreCategoria);
            return comando;
        }
        #endregion
        #region insertar
        /// <summary>
        /// Método que inserta en la base de datos una planta con los datos de la planta recibida por parametro
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>int filasAfectadas</returns>
        public static int InsertCategoria(clsCategoria categoria)
        {
            SqlConnection sqlConnection = connection.getConnection();
            SqlCommand comando = SqlCommandCParametros(categoria);
            comando.CommandText = "INSERT INTO Categorias VALUES (@id, @nombre)";
            comando.Connection = sqlConnection;
            int filasAfectadas = comando.ExecuteNonQuery();
            connection.closeConnection(ref sqlConnection);
            return filasAfectadas;
        }
        #endregion
        #region update
        /// <summary>
        /// Método que actualiza los datos de la planta en la bdd cuyo id coincide con el de la planta recibida por parametro y le establece sus datos
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>int filasAfectadas</returns>
        public static int UpdateCategoria(int idCategoria, clsCategoria categoria)
        {
            SqlConnection sqlConnection = connection.getConnection(); 
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@id", idCategoria);
            comando.Parameters.AddWithValue("@nombre", categoria.nombreCategoria);
            comando.CommandText = "UPDATE Categorias SET nombreCategoria=@nombre WHERE idCategoria=@id";
            comando.Connection = sqlConnection;
            int filasAfectadas = comando.ExecuteNonQuery();
            connection.closeConnection(ref sqlConnection);
            return filasAfectadas;
        }
        #endregion
        #region delete
        /// <summary>
        /// Método que ejecuta una instruccion delete para borrar la planta con el id especificado en la BDD
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns>int filasAfectadas</returns>
        public static int DeleteCategoria(int idCategoria)
        {
            SqlConnection sqlConnection = connection.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@id", idCategoria);
            comando.CommandText = "DELETE FROM Plantas WHERE (idCategoria=@id)";
            comando.Connection = sqlConnection;
            int filasAfectadas = comando.ExecuteNonQuery();
            connection.closeConnection(ref sqlConnection);
            return filasAfectadas;
        }
        #endregion
    }
}
