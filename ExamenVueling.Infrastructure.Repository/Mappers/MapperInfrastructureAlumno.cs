using AutoMapper;
using ExamenVueling.Domain.Models;
using ExamenVueling.Infrastructure.Repository.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Infrastructure.Repository.Mappers
{
    public class MapperInfrastructureAlumno
    {
        public static AlumnoEntity AlumnoDataModelToAlumnoEntity(Alumno alumno)
        {
            AlumnoEntity alumnoEntity = new AlumnoEntity(alumno.Id, alumno.Nombre, alumno.Apellidos, alumno.Dni, alumno.FechaNacimiento, alumno.Edad);

            return alumnoEntity;
        }


        public static List<AlumnoEntity> AlumnoDataModelToAlumnoEntity(List<Alumno> listadoAlumnoDataModel)
        {
            List<AlumnoEntity> listadoAlumnosEntity = new List<AlumnoEntity>();

            foreach( var alumno in listadoAlumnoDataModel )
            {
                listadoAlumnosEntity.Add(AlumnoDataModelToAlumnoEntity(alumno));
            }

            return listadoAlumnosEntity;
        }

        public static AlumnoEntity AlumnoToAlumnoEntity(Alumno alumno)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Alumno, AlumnoEntity>());
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<Alumno, AlumnoEntity>(alumno);
        }

    }
}
