using CRUD_Personas_BL;
using FryGuillermo_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FryGuillermo_UI.ViewModels
{
    public class VmListadoPlantas
    {

        public List<clsPlanta> ListadoPlantas() {
            return clsListadoPlantasBL.getListadoPlantas();
        }
        public List<clsCategoria> ListadoCategorias(){
            return clsListadoCategoriasBL.getListadoCategorias();
        
        }


        public VmListadoPlantas(){
          
       }
    }
}
