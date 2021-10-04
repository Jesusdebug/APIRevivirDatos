using ApiRevivirDatos.Datos.Models;
using APIRevivirDatos.ETL;
using ETLBox.Connection;
using OfficeOpenXml;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace APIRevivirDatos.SP
{
    public class LogicCasa
    {
        private CuidadConnection bd;
        public LogicCasa()
        {
            bd = new CuidadConnection();
        }
        public IEnumerable<Casa> GetAll()
        {
            var casas = bd.Casas;
            return casas;
        }   
        public IEnumerable<Casa> Get(int id)
        {
            //traemos el procedimineto almacenado 
            Thread contar = new Thread(contador);
            contar.Start();
            //craemos el procedimineto almacenado 
            //Thread imprime = new Thread(imprimir);
            //imprime.Start();
            var result = bd.Casas.Where(x => x.id == id);
            return result;
           // imprime.Join();
        }
        private void imprimir()
        {
            CuidadConnection bd = new CuidadConnection();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(@"C:\Users\00517\source\repos\APIRevivirDatos\APIRevivirDatos\copia.xlsx");
            var house = GetAll();
            var paqk = new ExcelPackage(file);
            var ws = paqk.Workbook.Worksheets.Add("Casas");
            var rango = ws.Cells["a1"].LoadFromCollection(bd.Casas, PrintHeaders: true);
            rango.AutoFitColumns();
            paqk.Save();
        }
        private void contador()
        {
            CuidadConnection bd = new CuidadConnection();
            int n = 1;
            string consul = "peticion por id";
            Contador contador = new Contador();
            contador.Contador1 = n;
            contador.cosulta = consul;
            bd.Contadors.Add(contador);
            bd.SaveChanges();
        }
        //TODO
        public void ProceETL(Copia copia)
        {

            ///ebemos establecer una conceccion maestra 
            ///-
            ///
            var masterConnection = new SqlConnectionManager("Data Source=DESKTOP-DS829OU; Catalog=Cuidad;User Id=sa; Trusted_Connection=True;");

            var dbConnection = new SqlConnectionManager("Data Source=DESKTOP-DS829OU;User Id=sa; Trusted_Connection=True;Initial Catalog=Ciudad;");
            //CreateTableTask.Create(dbConnection, "Copia", new List<TableColumn>()
            //{
            //    //new TableColumn("ID","int", allowNulls:false, isPrimaryKey:true, isIdentity:true),
            //    //new TableColumn("NombrePais","nvarchar(100)", allowNulls:true),
            //    //new TableColumn("NombreDepartamento","smallint", allowNulls:true),
            //    //new TableColumn("NombreCiudad","smallint", allowNulls:true),
            //    //new TableColumn("Calle","smallint", allowNulls:true),
            //    //new TableColumn("NumeroCasa","smallint", allowNulls:true)
            //});
            int row = 2;
            string path = @"C:\Users\00517\source\repos\APIRevivirDatos\APIRevivirDatos\copia.xlsx";
            SLDocument sLDocument = new SLDocument(path);
            List<Casa> casa = new List<Casa>();
            while (!String.IsNullOrEmpty(sLDocument.GetCellValueAsString(row, 1)))
            {
                //casa.NombreCiudad= sLDocument
                // row++;
            }

            //recrear la base de datos 
            // DropTableTask.DropIfExists(masterConnection, "Copia");
            // CreateTableTask.Create(masterConnection, "Copia");
            // Obtener el administrador de conexiones para crear una base de datos previamente
            //var dbConnection = new SqlConnectionManager("Data Source=DESKTOP-DS829OU;User Id=sa; Trusted_Connection=True;Initial Catalog=Ciudad;");
            ////vcracion de tablas en la base de datos 
            //CreateTableTask.Create(dbConnection, "Copia", new List<TableColumn>()
            //{
            //    new TableColumn("ID","int",allowNulls:false, isPrimaryKey:true, isIdentity:true),
            //    new TableColumn("Col1","nvarchar(100)",allowNulls:true),
            //    new TableColumn("Col2","smallint",allowNulls:true)
            //});


        }
        public bool registrar(Casa casa)
        {
            bool regitrado = false;
            try
            {
                Casa Regcasa = new Casa();
                Regcasa.NombreCiudad = casa.NombreCiudad;
                Regcasa.NombreDepartamento = casa.NombreDepartamento;
                Regcasa.NombrePais = casa.NombrePais;
                Regcasa.NumeroCasa = casa.NumeroCasa;
                Regcasa.Calle = casa.Calle;
                bd.Casas.Add(Regcasa);
                bd.SaveChanges();
                regitrado = true;
                return regitrado;
            }
            catch (Exception)
            {
                return regitrado;
            }


        }
        public bool registraCasa(Casa casa)
        {
            Casa Regcasa = new Casa();
            Regcasa.NombreCiudad = casa.NombreCiudad;
            Regcasa.NombreDepartamento = casa.NombreDepartamento;
            Regcasa.NombrePais = casa.NombrePais;
            Regcasa.NumeroCasa = casa.NumeroCasa;
            Regcasa.Calle = casa.Calle;
            bd.Casas.Add(Regcasa);
            bd.SaveChanges();
            return true;
        }
        public IEnumerable<Casa> mostrar()
        {
            var casas = bd.Casas;
            return casas;
        }
    }
}