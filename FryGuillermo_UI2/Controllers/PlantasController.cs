using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FryGuillermo_UI2.ViewModels;
using FryGuillermo_DAL;

namespace FryGuillermo_UI2.Controllers
{
    public class PlantasController : Controller
    {
        public IActionResult Index(string resultado)
        {
            VmListadoPlantas vm = new VmListadoPlantas();
            if (!string.IsNullOrEmpty(resultado))
            {
                ViewData["resultado"] = resultado;
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(int selectCategorias)
        {
            VmListadoPlantas vm = new VmListadoPlantas();
            vm.IdCategoriaSeleccionada = selectCategorias;
            return View(vm);
         }
        public IActionResult EditarPlanta(int idPlanta){
            VmListadoPlantas vm = new VmListadoPlantas();
            return View(vm.plantaSeleccionada(idPlanta));
        }
        [HttpPost]
        public IActionResult EditarPlanta(int IdPlanta,double Precio){
            IActionResult view = null;
            if (ModelState.IsValid)
            {
                clsGestoraPlanta.editarPrecioPlanta(IdPlanta, Precio);
                view = RedirectToAction("Index", new { resultado = "precio cambiado con éxito"});
            }
            else {
                view = View(new ViewModels.VmListadoPlantas().plantaSeleccionada(IdPlanta));
            }
            return view;
        }
    }
}
