using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Dto
{
    public class AlumnoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public AlumnoDto() { }

        public AlumnoDto(string nombre, string apellido, string dni, DateTime fechaNacimiento)
        {
            this.Nombre = nombre;
            this.Apellidos = apellido;
            this.Dni = dni;
            this.FechaNacimiento = fechaNacimiento;
        }

        public AlumnoDto(int id, string nombre, string apellido, string dni, DateTime fechaNacimiento)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellido;
            this.Dni = dni;
            this.FechaNacimiento = fechaNacimiento;
        }
    }
}
