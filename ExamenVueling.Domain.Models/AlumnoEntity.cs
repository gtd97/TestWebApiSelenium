using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Domain.Models
{
    public class AlumnoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }

        public AlumnoEntity() { }

        public AlumnoEntity(int id, string nombre, string apellido, string dni, DateTime fechaNacimiento, int edad)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellido;
            this.Dni = dni;
            this.FechaNacimiento = fechaNacimiento;
            this.Edad = edad;
        }
    }
}
