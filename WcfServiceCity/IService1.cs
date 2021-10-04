using ApiRevivirDatos.Datos.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace WcfServiceCity
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Casa> GetCasas();
    }
}
