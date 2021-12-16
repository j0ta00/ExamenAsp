using CRUD_Personas_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FryGuillermo_DAL
{
    public class clsManagerPlanta
    {
        public static void editarPlanta(int idPlanta, double precio) {
            new clsUtilsQuery().editarPlanta(idPlanta,precio);       
        }

    }
}
