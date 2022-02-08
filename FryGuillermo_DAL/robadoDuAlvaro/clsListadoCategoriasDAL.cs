using _07_CRUD_Personas_DAL.Conexion;
using FryGuillermo2_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoExamen_DAL.Categorias
{
    public class clsListadoCategoriasDAL
    {
        static clsMyConnection connector;

        public clsListadoCategoriasDAL()
        {
            connector = new clsMyConnection();
        }
        /// <summary>
        /// Método que ofrece el listado completo de categorias de la bdd
        /// </summary>
        /// <returns>List(clsCategoria)</returns>
        public static List<clsCategoria> ListadoCategorias()
        {
            List<clsCategoria> listadoCompleto = new List<clsCategoria>();
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM categorias";
            comando.Connection = sqlConnection;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listadoCompleto.Add(LeerCategoria(reader));
                }
            }
            reader.Close();
            connector.closeConnection(ref sqlConnection);
            return listadoCompleto;
        }
        /// <summary>
        /// Método auxiliar para leer categorias de la bdd
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>clsCategoria</returns>
        private static clsCategoria LeerCategoria(SqlDataReader reader)
        {
            int id = (int)reader["idCategoria"];
            string nombre = (string)(reader["nombreCategoria"] != DBNull.Value ? reader["nombreCategoria"] : "");
            return new clsCategoria(id, nombre);
        }
    }
}
