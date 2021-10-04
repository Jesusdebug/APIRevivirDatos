using ApiRevivirDatos.Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIRevivirDatos.Controllers
{
    public class LogicArchivo
    {
        private CuidadConnection bd;
        public LogicArchivo()
        {
            bd = new CuidadConnection();
        }
        public IEnumerable<Archivo> GetArchivos()
        {
            IEnumerable<Archivo> archivos;
            archivos = bd.Archivos.ToArray();
            return archivos;
        }
        public IEnumerable<Archivo> GetArchivos(int id)
        {
            var archivos = bd.Archivos.Where(x=>x.Id==id);
            return archivos;
        }
        public bool RegistrarArchivo(Archivo archivo)
        {
            try
            {
                Archivo regArchivo = new Archivo();
                regArchivo.Nombre = archivo.Nombre;
                regArchivo.Ruta = archivo.Ruta;
                regArchivo.Cantidad = archivo.Cantidad;
                regArchivo.Fecha = archivo.Fecha;
                bd.Archivos.Add(regArchivo);
                bd.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }
    }
}