using FryGuillermo_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FryGuillermo_BL
{
    public class clsGestoraPlantaBL
    {

        public static int editarPrecioPlanta(int idPlanta,double precio){
            return clsGestoraPlanta.editarPrecioPlanta(idPlanta,precio);
        }

    }
}
