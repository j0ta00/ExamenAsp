using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FryGuillermo_UI.ViewModels;

namespace FryGuillermo_UI.Controllers
{
    public class PlantasController : Controller
    {
        public IActionResult Index()
        {
            VmListadoPlantas vm = new VmListadoPlantas();
            return View(vm);
        }
    }
}
