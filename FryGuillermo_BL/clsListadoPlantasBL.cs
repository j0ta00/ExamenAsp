using CRUD_Personas_DAL.List;
using FryGuillermo2_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL
{
    public class clsListadoPlantasBL
    {
        /// <summary>
        /// Get a list of people from the DAL(Data Access Layer) 
        /// </summary>
        /// <returns>the person whose id coincidate with the id passing trough param(List(clsPerson) person)</returns>
        public static List<clsPlanta> getListadoPlantas(int idCategoria){
            return clsListadoDePlantasDAL.getListadoPlantas(idCategoria);
        }
        /// <summary>
        /// Get one people from the DAL(Data Access Layer) 
        /// </summary>
        /// <param name="id">the id of the person(int id)</param>
        /// <returns>the person whose id coincidate with the id passing trough param(clsPerson person)</returns>
        public static clsPlanta getUnaPlanta(int id){
            return clsListadoDePlantasDAL.getUnaPlanta(id);
        }
    }
}
