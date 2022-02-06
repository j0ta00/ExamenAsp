using FryGuillermo2_Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FryGuillermo_UI2.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantasController : ControllerBase
    {
        // GET: api/<PlantasController>
        [HttpGet("plantas/{idCategoria}")]
        public ObjectResult Get(int idCategoria)
        {
            List<clsPlanta> listaPlantas = null;
            ObjectResult result = new ObjectResult(new { Value = listaPlantas });
            try
            {
                result.Value = FryGuillermo_BL.clsListadoPlantasBL.getListadoPlantas(idCategoria);
                result.StatusCode = (int)System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                result.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            }
            if (result.Value == null || (result.Value as List<clsPlanta>).Count == 0)
            {
                result.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            }
            return result;
        }

        // GET api/<PlantasController>/5
        [HttpGet("planta/{idPlanta}")]
        public ObjectResult GetUnaPlanta(int idPlanta)
        {
            clsPlanta planta = null;
            ObjectResult result = new ObjectResult(new { Value = planta});
            try
            {
                result.Value = FryGuillermo_BL.clsListadoPlantasBL.getUnaPlanta(idPlanta);
                result.StatusCode = (int)System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                result.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            }
            if (result.Value == null)
            {
                result.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            }
            return result;
        }

        // POST api/<PlantasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
          

        }

        // PUT api/<PlantasController>/5
        [HttpPut("{id}")]
        public ObjectResult Put([FromBody] int idPlanta, double precio)
        {
            int filasAfectadas = 0;
            ObjectResult result = new ObjectResult(new { Value = filasAfectadas });
            try
            {
                result.Value = FryGuillermo_BL.clsGestoraPlantaBL.editarPrecioPlanta(idPlanta, precio);
                result.StatusCode = (int)System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                result.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            }
            if (result.Value == null)
            {
                result.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            }
            return result;
        }

        // DELETE api/<PlantasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
