using AutoMapper;
using ExamenVueling.Application.Dto;
using ExamenVueling.Application.Services.Contracts;
using ExamenVueling.Application.Services.Mappers;
using ExamenVueling.Common.Layer;
using ExamenVueling.Domain.Models;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Infrastructure.Repository.DataModel;
using ExamenVueling.Infrastructure.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Service
{
    public class AlumnoService : IService<AlumnoDto>
    {
        private readonly IRepository<AlumnoEntity> iRepository;

        // Con el this en el constructor, estamos creando un instancia, pero no haria un acomplamiento "falsa inyeccion de dependencias"
        public AlumnoService() : this(new AlumnoRepository())
        {
        }

        public AlumnoService(AlumnoRepository alumnoRepository)
        {
            this.iRepository = alumnoRepository;
        }

        // Este alumno dto no tiene id, y el que devuelve tiene id, se tendra que hacer un reverse map
        public AlumnoDto Add(AlumnoDto alumnoDto)
        {
            AlumnoEntity alumnoEntity;

            try
            {
                alumnoEntity = iRepository.Add( MappersServicesAlumno.AlumnoDtoToAlumnoEntity(alumnoDto) );
            }
            catch(VuelingExceptions ex)
            {
                // Log
                throw ex;
            }

            return MappersServicesAlumno.AlumnoEntityToAlumnoDto(alumnoEntity);
        }

        public List<AlumnoDto> GetAll()
        {
            try
            {
                List<AlumnoEntity> listadoAlumnosEntity = iRepository.GetAll();
                List<AlumnoDto> listadoAlumnosDto = MappersServicesAlumno.AlumnoEntityToAlumnoDto(listadoAlumnosEntity);
                return listadoAlumnosDto;
            }
            catch (VuelingExceptions ex)
            {
                // Log
                throw ex;
            }
        }

        public AlumnoDto GetById(int id)
        {
            AlumnoDto alumnoDto;

            try
            {
                AlumnoEntity alumnoEntity = iRepository.GetById(id);
                alumnoDto = MappersServicesAlumno.AlumnoEntityToAlumnoDto(alumnoEntity);
                
            }
            catch (VuelingExceptions ex)
            {
                // Log
                throw ex;
            }

            return alumnoDto;
        }

        public int Remove(int id)
        {
            int resultado;

            try
            {
                resultado = iRepository.Remove(id);
            }
            catch (VuelingExceptions ex)
            {
                // Log
                throw ex;
            }

            return resultado;
        }

        public AlumnoDto Update(AlumnoDto alumnoDto)
        {
            try
            {
                AlumnoEntity alumnoEntity = MappersServicesAlumno.AlumnoDtoToAlumnoEntity(alumnoDto);
                iRepository.Update(alumnoEntity);
                return MappersServicesAlumno.AlumnoEntityToAlumnoDto(alumnoEntity);
            }
            catch (VuelingExceptions ex)
            {
                // Log
                throw ex;
            }
        }

    }
}
