﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiRevivirDatos.Datos.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CuidadConnection : DbContext
    {
        public CuidadConnection()
            : base("name=CuidadConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Archivo> Archivos { get; set; }
        public virtual DbSet<Casa> Casas { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Contador> Contadors { get; set; }
    }
}
