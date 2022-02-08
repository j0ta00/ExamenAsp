using FryGuillermo2_Entities;
using Proyecto_Examen_DAL.Categorias;
using ProyectoExamen_DAL.Categorias;
using System;
using System.Collections.Generic;
using System.Text;

namespace FryGuillermo_BL.robadoDuAlvaro
{
    public class clsGestoraCategoriasBL
    {

        public static int insertarCategoria(clsCategoria categoria) {
            return clsGestoraCategoriasDAL.InsertCategoria(categoria);

        }
        public static int deleteCategoria(int id)
        {
            return clsGestoraCategoriasDAL.DeleteCategoria(id);

        }
        public static int actualizarCategoria(int id, clsCategoria categoria)
        {
            return clsGestoraCategoriasDAL.UpdateCategoria(id, categoria);

        }

        

    }
}
