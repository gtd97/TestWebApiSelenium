using ExamenVueling.Application.Dto;
using ExamenVueling.Application.Services.Contracts;
using ExamenVueling.Application.Services.Service;
using ExamenVueling.Common.Layer;
using ExamenVueling.Domain.Models;
using ExamenVueling.Infrastructure.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ExamenVueling.Facade.Api.Controllers
{
    public class AlumnoApiController : ApiController
    {
        private readonly IService<AlumnoDto> alumnoService;

        // Con el this en el constructor, estamos creando un instancia, pero no haria un acomplamiento "falsa inyeccion de dependencias"
        public AlumnoApiController() : this(new AlumnoService())
        {
        }

        public AlumnoApiController(AlumnoService alumnoService)
        {
            this.alumnoService = alumnoService;
        }


        // GET: api/AlumnoApi
        public IHttpActionResult Get()
        {
            List<AlumnoDto> lista = alumnoService.GetAll();

            if (lista != null)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound();
            }

            //throw new NotImplementedException("The method is not implemented yet");
            // devuelve un IQueriable<Alumno> -> es optimo con linq
        }

        // GET: api/AlumnoApi/5
        public IHttpActionResult Get(int id)
        {
            AlumnoDto alumnoDto = alumnoService.GetById(id);
            if (alumnoDto == null)
            {
                return NotFound();
            }

            return Ok(alumnoDto);
        }

        // POST: api/AlumnoApi
        [ResponseType(typeof(AlumnoDto))]
        public IHttpActionResult Post([FromBody] AlumnoDto alumnoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AlumnoDto alumnoDtoAdded;

            try
            {
                alumnoDtoAdded = alumnoService.Add(alumnoDto);
            }
            catch(VuelingExceptions ex)
            {
                // return the best http error
                throw ex;
            }

            return CreatedAtRoute("DefaultApi", new { id = alumnoDtoAdded.Id }, alumnoDtoAdded);
        }

        // PUT: api/AlumnoApi/5
        //public void Put(int id, AlumnoEntity alumno)
        [ResponseType(typeof(AlumnoDto))]
        public IHttpActionResult Put(int id, AlumnoDto alumnoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alumnoDto.Id)
            {
                return BadRequest();
            }
            
            AlumnoDto alumnoDtoInserted = alumnoService.Update(alumnoDto);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/AlumnoApi/5
        public IHttpActionResult Delete(int id)
        {

            int alumnoDeleted = alumnoService.Remove(id);

            if (alumnoDeleted == 1)
            {
                return Ok(1);
            }
            else
            {
                return NotFound();
            }
           
        }
    }
}
