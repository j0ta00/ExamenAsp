using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FryGuillermo2_Entities
{
    public class clsPlanta
    {
        public int IdPlanta { get; set; }
        public string NombrePlanta { get; set; }
        public string DescripcionPlanta { get; set; }
        public int IdCategoria { get; set; }
        [Required]
        public double Precio { get; set; }

        public clsPlanta(){
            IdPlanta = 0;
            NombrePlanta = "";
            DescripcionPlanta = "";
            IdCategoria = 0;
            Precio = 0;

        }

        public clsPlanta(int idPlanta,string nombrePlanta,string descripcionPlanta,int idCategoria,double precio){
            IdPlanta = idPlanta;
            NombrePlanta = nombrePlanta;
            DescripcionPlanta = descripcionPlanta;
            IdCategoria = idCategoria;
            Precio = precio;
        }
    }
}
