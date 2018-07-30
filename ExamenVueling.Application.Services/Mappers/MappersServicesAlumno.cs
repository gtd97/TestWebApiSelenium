using AutoMapper;
using ExamenVueling.Application.Dto;
using ExamenVueling.Domain.Models;
using ExamenVueling.Infrastructure.Repository.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Mappers
{
    public class MappersServicesAlumno
    {
        /// <summary>
        /// Mapper de un solo alumno AlumnoEntity a AlumnoDto.
        /// </summary>
        /// <param name="alumnoEntity">The alumno entity.</param>
        /// <returns></returns>
       public static AlumnoDto AlumnoEntityToAlumnoDto(AlumnoEntity alumnoEntity)
       {
            AlumnoDto alumnoDto = new AlumnoDto { Id = alumnoEntity.Id, Nombre = alumnoEntity.Nombre, Apellidos = alumnoEntity.Apellidos, Dni = alumnoEntity.Dni, FechaNacimiento = alumnoEntity.FechaNacimiento };

            return alumnoDto;
       }


        /// <summary>
        /// Mapper de un Listado de AlumnosEntity a Listado Alumnos Dto.
        /// </summary>
        /// <param name="listaAlumnoEntity">The lista alumno entity.</param>
        /// <returns></returns>
        public static List<AlumnoDto> AlumnoEntityToAlumnoDto(List<AlumnoEntity> listaAlumnoEntity)
        {
            List<AlumnoDto> listaAlumnosDto = new List<AlumnoDto>();

            foreach (var alumno in listaAlumnoEntity)
            {
                listaAlumnosDto.Add(AlumnoEntityToAlumnoDto(alumno));
            }

            return listaAlumnosDto;
        }


        /// <summary>
        /// Mapp de AlumnoDto a AlumnoEntity
        /// </summary>
        /// <param name="alumnoDto">The alumno dto.</param>
        /// <returns></returns>
        public static AlumnoEntity AlumnoDtoToAlumnoEntity(AlumnoDto alumnoDto)
        {
            int edad = DateTime.Today.AddTicks(-alumnoDto.FechaNacimiento.Ticks).Year - 1;
            AlumnoEntity alumnoEntity = new AlumnoEntity(alumnoDto.Id, alumnoDto.Nombre, alumnoDto.Apellidos, alumnoDto.Dni, alumnoDto.FechaNacimiento, edad);

            return alumnoEntity;
        }
        
        

    }
}
