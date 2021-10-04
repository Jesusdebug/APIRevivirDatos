
using ApiRevivirDatos.Datos.Models;
using System.Collections.Generic;
using System.Linq;

namespace WcfServiceCity
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {

        private CuidadConnection bd;
        public Service1()
        {
            bd = new CuidadConnection();
        }
        public List<Casa> GetCasas()
        {
            var ls = bd.Casas.ToList();
            return ls;
        }
    }
}
