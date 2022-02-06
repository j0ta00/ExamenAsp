using CRUD_Personas_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FryGuillermo_DAL
{
    public class clsGestoraPlanta
    {
        public static int editarPrecioPlanta(int idPlanta, double precio) {
            return new clsUtilsQuery().editarPlanta(idPlanta,precio);       
        }

    }
}
