using ApiRevivirDatos.Datos.Models;
using APIRevivirDatos.Logic;
using System;
using System.Web.Http;

namespace APIRevivirDatos.Controllers
{
    public class ArchivoController : ApiController
    {
        private LogicArchivo _LogicArchivo;
        public ArchivoController()
        {
            _LogicArchivo = new LogicArchivo();
        }
        [HttpGet]
        public IHttpActionResult GetLogicArchivos()
        {
            return Ok(_LogicArchivo.GetArchivos());
        }
        [HttpGet]
        public IHttpActionResult GetLogicArchivos(int id)
        {
            return Ok(_LogicArchivo.GetArchivos(id));
        }
        [HttpPost]
        public IHttpActionResult Post(Archivo archivo)
        {
            bool respuesta = _LogicArchivo.RegistrarArchivo(archivo);
            try
            {

                if (respuesta)
                {
                    return Ok("regitro del archivo completo");
                }
                else
                {
                    return BadRequest("Intenta de nuevo el registro, reviasa los datos del archivo");
                }

            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }

        }
    }
}
