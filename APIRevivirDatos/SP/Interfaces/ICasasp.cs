using ApiRevivirDatos.Datos.Models;
using System.Collections.Generic;

namespace APIRevivirDatos.SP.Interfaces
{
    public interface ICasasp
    {
        IEnumerable<Casa> GetAll();
        IEnumerable<Casa> Getsp(int id);

        bool registrar(Casa regCasas);

    }
}