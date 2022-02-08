using FryGuillermo2_Entities;
using ProyectoExamen_DAL.Plantas;
using System;
using System.Collections.Generic;
using System.Text;

namespace FryGuillermo_BL.robadoDuAlvaro
{
    public class clsGestoraPlantasBL
    {

        public static int cambiarPrecioPlanta(int idPlanta, double precio)
        {
            return clsGestoraPlantasDAL.CambiarPrecio(idPlanta, precio);
        }

        public static int insertarPlanta(clsPlanta planta)
        {
            return clsGestoraPlantasDAL.InsertPlanta(planta);
        }

        public static int deletePlanta(int idPlanta)
        {
            return clsGestoraPlantasDAL.DeletePlanta(idPlanta);
        }

        public static int actualizarPlanta(int id,clsPlanta planta){
            return clsGestoraPlantasDAL.UpdatePlanta(id,planta);
        }
    }
}
