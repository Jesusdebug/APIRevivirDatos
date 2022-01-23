using ApiRevivirDatos.Datos.Models;
using APIRevivirDatos.Logic;
using System;
using System.Web.Http;

namespace APIRevivirDatos.Controllers
{
    public class ArchivoController : ApiController
    {
        private LogicArchivo _logicFile;
        public ArchivoController()
        {
            _logicFile = new LogicArchivo();
        }
        [HttpGet]
        public IHttpActionResult GetLogicArchivos()
        {
            return Ok(_logicFile.GetArchivos());
        }
        [HttpGet]
        public IHttpActionResult GetLogicArchivos(int id)
        {
            return Ok(_logicFile.GetArchivos(id));
        }
        [HttpPost]
        public IHttpActionResult Post(Archivo archivo)
        {
            bool respuesta = _logicFile.RegistrarArchivo(archivo);
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
