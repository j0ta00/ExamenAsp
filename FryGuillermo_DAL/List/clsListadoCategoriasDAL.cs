
using FryGuillermo2_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.List
{
    public class clsListadoCategoriasDAL
    {
        /// <summary>
        /// Method that returns a list of object person geted from a database
        /// </summary>
        /// <returns>list that contains all of departments(type: List(clsDepartment))</returns>
        public static List<clsCategoria> getListadoCategorias()
        {
            List<clsCategoria> listadoCategorias = new List<clsCategoria>();
            clsUtilsQuery utilsMyReader = new clsUtilsQuery();
            utilsMyReader.QuerySelect("SELECT * FROM categorias");                                
            if (utilsMyReader.MyReader.HasRows)
            {
                while (utilsMyReader.MyReader.Read())
                {
                    listadoCategorias.Add(leerUnaCategoria(utilsMyReader.MyReader));
                }
            }
            utilsMyReader.closeConnection();
            return listadoCategorias;
        }
        /// <summary>
        /// Method that returns one department geted from a database
        /// </summary>
        /// <param name="value">represents the id of the department that will be searched for in the query using it in the where condition</param>
        /// <returns>the object readed in the database(type:clsDepartment)</returns>
        public static clsCategoria getUnaCategoria(int value)
        {
            List<clsCategoria> listadoCategorias = new List<clsCategoria>();
            clsUtilsQuery utilsMyReader = new clsUtilsQuery();
            clsCategoria categoria = new clsCategoria();
            utilsMyReader.QuerySelectWithValueInt("SELECT * FROM categorias WHERE idCategoria = @id", value);           
            if (utilsMyReader.MyReader.HasRows)
            {
                utilsMyReader.MyReader.Read();

                    categoria = leerUnaCategoria(utilsMyReader.MyReader);
             }
            utilsMyReader.closeConnection();
            return categoria;
        }
        /// <summary>
        /// Method that build a object person with the data geted from a database and return this object
        /// </summary>
        /// <param name="reader">object reader, that read data from a database</param>
        /// <returns> the object readed in the database(type: clsDepartment)</returns>
        private static clsCategoria leerUnaCategoria(SqlDataReader reader)
        {
            clsCategoria oCategoria;
            oCategoria = new clsCategoria();
           if(reader["nombreCategoria"]!=DBNull.Value){ oCategoria.nombreCategoria = (string)reader["nombreCategoria"];}
            if (reader.FieldCount>1){oCategoria.IdCategoria = (int)reader["idCategoria"];}
            return oCategoria;
        }
    }
}
