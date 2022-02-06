
using FryGuillermo2_Entities;
using FryGuillermo_UI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FryGuillermo_BL;

namespace FryGuillermo_UI2.ViewModels
{
    public class VmListadoPlantas
    {
        public int IdCategoriaSeleccionada{ get; set;}
        public List<PlantaSoloNombreId> ListadoPlantas() {            
            List<PlantaSoloNombreId> listadoPlantas = new List<PlantaSoloNombreId>();
                clsListadoPlantasBL.getListadoPlantas(IdCategoriaSeleccionada).ForEach(planta => listadoPlantas.Add(new PlantaSoloNombreId(planta.IdPlanta, planta.NombrePlanta)));
                return listadoPlantas;
        }
        public clsPlanta plantaSeleccionada(int idPlanta){
            return clsListadoPlantasBL.getUnaPlanta(idPlanta);
        }


        public List<clsCategoria> ListadoCategorias(){
            return clsListadoCategoriasBL.getListadoCategorias();
        
        }

        public VmListadoPlantas(){
          
       }
    }
}
