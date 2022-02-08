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
    public class clsListadoPlantasDAL
    {
        #region propiedades privadas
        static clsMyConnection connector;
        #endregion
        #region constructor
        public clsListadoPlantasDAL()
        {
            connector = new clsMyConnection();
        }
        #endregion
        #region leerPlanta
        /// <summary>
        /// Extrae de la bbdd los datos de la planta con el id que recibe por parametro y devuelve un objeto de la clase clsPlanta con dichos datos
        /// </summary>
        /// <param name="idPlanta"></param>
        /// <returns> clsPlanta </returns>
        public static clsPlanta LeerPlantaPorId(int idPlanta)
        {
            clsPlanta planta = null;
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@id", idPlanta);
            comando.CommandText = "SELECT * FROM plantas WHERE idPlanta=@id";
            comando.Connection = sqlConnection;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    planta = LeerPlanta(reader);
                }
            }
            reader.Close();
            connector.closeConnection(ref sqlConnection);
            return planta;
        }
        /// <summary>
        /// Método auxiliar para leer y validar los datos del reader al leer una planta
        /// </summary>
        /// <param name="reader"></param>
        /// <returns> clsPlanta </returns>
        private static clsPlanta LeerPlanta(SqlDataReader reader)
        {
            int id = (int)reader["idPlanta"];
            string nombre= (reader["nombrePlanta"]!=DBNull.Value) ? (string)reader["nombrePlanta"] : ""; 
            string descripcion = (reader["descripcion"] != DBNull.Value) ? (string)reader["descripcion"] : "";
            int idCategoria=(reader["idCategoria"] != DBNull.Value) ? (int)reader["idCategoria"] : 0;
            double precio = (reader["precio"]!=DBNull.Value)? (double)reader["precio"] : 0;
            return new clsPlanta(id, nombre, descripcion, idCategoria, precio);
        }
        #endregion
        #region listadoPlantas
        /// <summary>
        /// Guarda el contenido de la tabla plantas de la bdd en una lista filtrado por el id de la categoria especificado por parametro 
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns> List(clsPlanta) </returns>
        public static List<clsPlanta> ListadoPorIdCategoria(int idCategoria)
        { 
            List<clsPlanta> plantas = new List<clsPlanta>();
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@idCat", idCategoria);
            comando.CommandText = "SELECT * FROM plantas WHERE idCategoria=@idCat";
            comando.Connection = sqlConnection;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    plantas.Add(LeerPlanta(reader));
                }
            }
            reader.Close();
            connector.closeConnection(ref sqlConnection);
            return plantas;
        }
        /// <summary>
        /// Accede a la base de datos para devolver un listado completo de objetos planta
        /// </summary>
        /// <returns> List(clsPlanta) </returns>
        public static List<clsPlanta> ListadoCompletoPlantas()
        {
            List<clsPlanta> plantas = new List<clsPlanta>();
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM plantas";
            comando.Connection = sqlConnection;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    plantas.Add(LeerPlanta(reader));
                }
            }
            reader.Close();
            connector.closeConnection(ref sqlConnection);
            return plantas;
        }
        #endregion

    }
}
