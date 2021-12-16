using System;
using System.Collections.Generic;
using System.Text;

namespace FryGuillermo2_Entities
{
    public class clsCategoria
    {
        public int IdCategoria { get; set; }
        public string nombreCategoria { get; set; }

        public clsCategoria(int idCategoria, string nombreCategoria)
        {
            IdCategoria = idCategoria;
            this.nombreCategoria = nombreCategoria;
        }
        public clsCategoria(){
            IdCategoria = 0;
            this.nombreCategoria = "";

        }
    }
}
