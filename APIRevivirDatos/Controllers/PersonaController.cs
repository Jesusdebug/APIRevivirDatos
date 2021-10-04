using ApiRevivirDatos.Datos.Models;
using APIRevivirDatos.Logic;
using System;
using System.Web.Http;

namespace APIRevivirDatos.Controllers
{
    public class PersonaController : ApiController
    {
        private LogicPersona _logicPersona;
        public PersonaController()
        {
            _logicPersona = new LogicPersona();
        }
        [HttpPost]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            return Ok(_logicPersona.GetAll());
        }
        [HttpPost]
        [Route("id")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_logicPersona.Get(id));
        }
        [HttpPost]
        [Route("registrar")]
        public IHttpActionResult registra(Persona persona)
        {
            bool resultado = _logicPersona.registrar(persona);
            if (resultado)
            {
                return Ok("Exito");
            }
            else
            {
                return BadRequest("Intenta  nuevamente");
            }
        }
        [HttpPost]
        [Route("actualizar")]
        public IHttpActionResult actualizar(Persona persona)
        {
            try
            {
                bool respuesta = _logicPersona.acturalizar(persona);
                if (respuesta)
                {
                    return Ok("Datos Acutalizados");
                }
                else
                {
                    return Ok("No se acutalizaron");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
