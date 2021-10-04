using ApiRevivirDatos.Datos.Models;
using APIRevivirDatos.Logic;
using System;
using System.Web.Http;
namespace APIRevivirDatos.Controllers
{
    public class CasaController : ApiController
    {
        private LogicCasa _casa;
        public CasaController()
        {
            _casa= new LogicCasa();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_casa.GetAll());
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_casa.Get(id));
        }
        [HttpPost]
        ///se recine un objeto de entidad?
        public bool Post(Casa casa)
        {
            try
            {
                bool resultado = _casa.registraCasa(casa);
                if (resultado)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        [HttpPost]
        [Route("api/getId")]
        public IHttpActionResult GetId(int id)
        {
            return Ok(_casa.Get(id));
        }
    }
}
