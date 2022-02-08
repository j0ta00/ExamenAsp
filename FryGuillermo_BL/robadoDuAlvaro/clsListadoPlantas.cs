using FryGuillermo2_Entities;
using ProyectoExamen_DAL.Plantas;
using System;
using System.Collections.Generic;
using System.Text;

namespace FryGuillermo_BL.robadoDuAlvaro
{
    public class clsListadoPlantas
    {
        public static List<clsPlanta> obtenerListadoCompletosPlantas(){
            return clsListadoPlantasDAL.ListadoCompletoPlantas();
        }
        public static clsPlanta obtenerPlantaPorId(int id)
        {
            return clsListadoPlantasDAL.LeerPlantaPorId(id);
        }

        public static List<clsPlanta> obtenerListadoCompletosPlantasPorCategoria(int idCategoria)
        {
            return clsListadoPlantasDAL.ListadoPorIdCategoria(idCategoria);
        }
    }
}
