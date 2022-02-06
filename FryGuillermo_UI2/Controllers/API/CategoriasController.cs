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
    public class CategoriasController : ControllerBase
    {
        // GET: api/<CategoriasController>
        [HttpGet]
        public ObjectResult Get()
        {
            List<clsCategoria> listaCategorias = null;
            ObjectResult result = new ObjectResult(new {Value = listaCategorias});
            try
            {
                result.Value = FryGuillermo_BL.clsListadoCategoriasBL.getListadoCategorias();
                result.StatusCode = (int)System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                result.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            }
            if (result.Value == null || (result.Value as List<clsCategoria>).Count == 0)
            {
                result.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            }
            return result;
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            clsCategoria categoria = null;
            ObjectResult result = new ObjectResult(new { Value = categoria });
            try
            {
                result.Value = FryGuillermo_BL.clsListadoCategoriasBL.getUnaCategoria(id);
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

        // POST api/<CategoriasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
