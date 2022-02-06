
using CRUD_Personas_DAL.List;
using FryGuillermo2_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FryGuillermo_BL
{
    public class clsListadoCategoriasBL
    {
        /// <summary>
        /// Returns a list of departments, with all departments storage in a database
        /// </summary>
        /// <returns>a list with all departments storage in a database(List(clsDepartment) listOfDepartments)</returns>
        public static List<clsCategoria> getListadoCategorias(){
            return clsListadoCategoriasDAL.getListadoCategorias();
        }
        /// <summary>
        /// Get one department from the DAL(Data Access Layer)  
        /// </summary>
        /// <param name="departmentId">the id of the department(int departmentId)</param>
        /// <returns>a specific department(department clsdepartment)</returns>
        public static clsCategoria getUnaCategoria(int categoriaId)
        {
            return clsListadoCategoriasDAL.getUnaCategoria(categoriaId);
        }
    }
}
