//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamenVueling.Infrastructure.Repository.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }

        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, string dni, DateTime fechaNacimiento, int edad)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellido;
            this.Dni = dni;
            this.FechaNacimiento = fechaNacimiento;
            this.Edad = edad;
        }

        public Alumno(string nombre, string apellido, string dni, DateTime fechaNacimiento, int edad)
        {
            this.Nombre = nombre;
            this.Apellidos = apellido;
            this.Dni = dni;
            this.FechaNacimiento = fechaNacimiento;
            this.Edad = edad;
        }
    }
}
