using ApiRevivirDatos.Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIRevivirDatos.SP.Logica
{
    public class LogicPersona
    {
        private CuidadConnection bd;
        public LogicPersona()
        {
            bd = new CuidadConnection();
        }
        public IEnumerable<Persona> GetAll()
        {
            var personas = bd.Personas;
            return personas;
        }
        public IEnumerable<Persona> Get(int id)
        {
            var persona = bd.Personas.Where(x=>x.IdPersona==id);
            return persona;
        }
        public bool registrar(Persona persona)
        {
            bool valido = false;
            try
            {
                Persona regpersona = new Persona();
                regpersona.Numero = persona.Numero;
                regpersona.NombreFamilia = persona.NombreFamilia;
                regpersona.TipoRelacion = persona.TipoRelacion;
                bd.Personas.Add(regpersona);
                bd.SaveChanges();
                valido = true;
                return valido;
            }
            catch (Exception)
            {
                return valido;
            }
        }
        public bool acturalizar(Persona persona)
        {
            bool respuesta = false;
            try
            {
                var actualizarPersona = bd.Personas.FirstOrDefault(x => x.IdPersona == persona.IdPersona);
                actualizarPersona.NombreFamilia = persona.NombreFamilia;
                actualizarPersona.Numero = persona.Numero;
                actualizarPersona.TipoRelacion = persona.TipoRelacion;
                bd.SaveChanges();
                respuesta = true;
                return respuesta;
            }
            catch (Exception)
            {
                return respuesta;
            }
        }
    }
}