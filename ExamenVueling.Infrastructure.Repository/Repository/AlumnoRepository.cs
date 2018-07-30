using ExamenVueling.Common.Layer;
using ExamenVueling.Domain.Models;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Infrastructure.Repository.DataModel;
using ExamenVueling.Infrastructure.Repository.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using ExamenVueling.Application.Dto;

namespace ExamenVueling.Infrastructure.Repository.Repository
{
    public class AlumnoRepository : IRepository<AlumnoEntity>
    {
        CovalcoEntities db = new CovalcoEntities();


        public AlumnoEntity Add(AlumnoEntity alumnoEntity)
        {
            AlumnoEntity alumnoEntityAdded;
            
            // Aqui se haria el automapper para pasar a objeto 
            try
            {
                Alumno alumnoDM = new Alumno(alumnoEntity.Nombre, alumnoEntity.Apellidos, alumnoEntity.Dni, alumnoEntity.FechaNacimiento, alumnoEntity.Edad);
                
                db.Alumno.Add(alumnoDM);
                db.SaveChanges();

                alumnoEntityAdded = MapperInfrastructureAlumno.AlumnoDataModelToAlumnoEntity(alumnoDM);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.DbUpdateConcurrencyException, ex);
            }
            catch (DbUpdateException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.DbUpdateException, ex);
            }
            catch (DbEntityValidationException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.DbEntityValidationException, ex);
            }
            catch (NotSupportedException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.NotSupportedException, ex);
            }
            catch (ObjectDisposedException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.ObjectDisposedException, ex);
            }
            catch (InvalidOperationException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.InvalidOperationException, ex);
            }

            return alumnoEntityAdded;
        }
        
        public List<AlumnoEntity> GetAll()
        {
            List<Alumno> listaAlumnos = db.Alumno.ToList();
            return MapperInfrastructureAlumno.AlumnoDataModelToAlumnoEntity(listaAlumnos);
        }

        public AlumnoEntity GetById(int id)
        {
            return MapperInfrastructureAlumno.AlumnoDataModelToAlumnoEntity(db.Alumno.Find(id));
        }

        public int Remove(int id)
        {
            Alumno alumno = db.Alumno.Find(id);
            if (alumno != null)
            {
                try
                {
                    db.Alumno.Remove(alumno);
                    db.SaveChanges();

                    return 1;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // YOU MUST LOG - Habria que hacer un log
                    throw new VuelingExceptions(ResourceMessage.DbUpdateConcurrencyException, ex);
                }
                catch (DbUpdateException ex)
                {
                    // YOU MUST LOG - Habria que hacer un log
                    throw new VuelingExceptions(ResourceMessage.DbUpdateException, ex);
                }
                catch (DbEntityValidationException ex)
                {
                    // YOU MUST LOG - Habria que hacer un log
                    throw new VuelingExceptions(ResourceMessage.DbEntityValidationException, ex);
                }
                catch (NotSupportedException ex)
                {
                    // YOU MUST LOG - Habria que hacer un log
                    throw new VuelingExceptions(ResourceMessage.NotSupportedException, ex);
                }
                catch (ObjectDisposedException ex)
                {
                    // YOU MUST LOG - Habria que hacer un log
                    throw new VuelingExceptions(ResourceMessage.ObjectDisposedException, ex);
                }
                catch (InvalidOperationException ex)
                {
                    // YOU MUST LOG - Habria que hacer un log
                    throw new VuelingExceptions(ResourceMessage.InvalidOperationException, ex);
                }
            }

            return 0;
        }

        public AlumnoEntity Update(AlumnoEntity alumnoEntity)
        {
            Alumno obtenerAlumno = db.Alumno.SingleOrDefault(x => x.Id == alumnoEntity.Id);
            AlumnoEntity obtenerAlumnoUpdated;

            //db.Entry(alumnoEntity).State = EntityState.Modified;
            try
            {
                obtenerAlumno.Nombre = alumnoEntity.Nombre;
                obtenerAlumno.Apellidos = alumnoEntity.Apellidos;
                obtenerAlumno.Dni = alumnoEntity.Dni;
                obtenerAlumno.FechaNacimiento = alumnoEntity.FechaNacimiento;
                obtenerAlumno.Edad = alumnoEntity.Edad;
                db.SaveChanges();

                Alumno alumno = db.Alumno.SingleOrDefault(x => x.Id == alumnoEntity.Id);
                obtenerAlumnoUpdated = MapperInfrastructureAlumno.AlumnoToAlumnoEntity(alumno);

            }
            catch (DbUpdateConcurrencyException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.DbUpdateConcurrencyException, ex);
            }
            catch (DbUpdateException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.DbUpdateException, ex);
            }
            catch (DbEntityValidationException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.DbEntityValidationException, ex);
            }
            catch (NotSupportedException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.NotSupportedException, ex);
            }
            catch (ObjectDisposedException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.ObjectDisposedException, ex);
            }
            catch (InvalidOperationException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.InvalidOperationException, ex);
            }
            catch (ArgumentNullException ex)
            {
                // YOU MUST LOG - Habria que hacer un log
                throw new VuelingExceptions(ResourceMessage.ArgumentNullException, ex);
            }

            return obtenerAlumnoUpdated;
        }
    }
}
