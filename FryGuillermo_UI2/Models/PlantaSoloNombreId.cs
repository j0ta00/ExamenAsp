using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FryGuillermo_UI2.Models
{
    public class PlantaSoloNombreId
    {
        public int IdPlanta { get; set;}
        public string nombrePlanta { get; set;}

        public PlantaSoloNombreId(int idPlanta, string nombrePlanta)
        {
            IdPlanta = idPlanta;
            this.nombrePlanta = nombrePlanta;
        }

        public PlantaSoloNombreId(){}
    }
}
