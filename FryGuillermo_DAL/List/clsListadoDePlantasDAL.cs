using _07_CRUD_Personas_DAL.Conexion;
using FryGuillermo2_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.List
{
    public class clsListadoDePlantasDAL
    {
        /// <summary>
        /// Method that returns a list of object person geted from a database
        /// </summary>
        /// <returns>list of people getted from the database(List(clsPerson))</returns>
        public static List<clsPlanta> getListadoPlantas(int idCategoria)
        {
            List<clsPlanta> listadoPlantas = new List<clsPlanta>();
            clsUtilsQuery utilsMyReader = new clsUtilsQuery();
            utilsMyReader.QuerySelectWithValueInt("SELECT * FROM plantas Where idCategoria=@id",idCategoria);
            if (utilsMyReader.MyReader.HasRows)
            {
                while (utilsMyReader.MyReader.Read())
                {
                    listadoPlantas.Add(leerUnaPlanta(utilsMyReader.MyReader));
                }
            }
            utilsMyReader.closeConnection();
            return listadoPlantas;
        }
        /// <summary>
        /// Method that build a object person with the data geted from a database and return this object
        /// </summary>
        /// <param>object reader that will read a person from a database(sqlDataReader reader)</param>
        /// <returns>object person readed from a datbase(clsPerson person)</returns>
        private static clsPlanta leerUnaPlanta(SqlDataReader reader)
        {
            clsPlanta oPlanta;
            oPlanta = new clsPlanta();
            oPlanta.IdPlanta = (int)reader["idPlanta"];
            oPlanta.NombrePlanta = (string)reader["nombrePlanta"];
            if (reader["descripcion"] != DBNull.Value) { oPlanta.DescripcionPlanta = (string)reader["descripcion"]; }
            oPlanta.IdCategoria= (int)reader["idCategoria"]; 
            if (reader["precio"] != DBNull.Value) { oPlanta.Precio = (double)reader["precio"]; } 
            return oPlanta;
        }
        /// <summary>
        /// Method that returns a person from the database
        /// </summary>
        /// <param>value that represent the id of a person object(int value) </param>
        /// <returns>the person readed in the database(ClsPerson person)</returns>
        public static clsPlanta getUnaPlanta(int value)
        {
            clsUtilsQuery utilsMyReader = new clsUtilsQuery();
            clsPlanta planta = new clsPlanta();
            utilsMyReader.QuerySelectWithValueInt("SELECT * FROM plantas WHERE idPlanta=@id", value);
            if (utilsMyReader.MyReader.HasRows)
            {
                utilsMyReader.MyReader.Read();

                planta = leerUnaPlanta(utilsMyReader.MyReader);
            }
            utilsMyReader.closeConnection();
            return planta;
        }

    }
}