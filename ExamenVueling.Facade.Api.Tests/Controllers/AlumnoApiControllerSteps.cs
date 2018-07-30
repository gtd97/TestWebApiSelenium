using ExamenVueling.Application.Dto;
using ExamenVueling.Application.Services.Contracts;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace ExamenVueling.Facade.Api.Tests
{
    [Binding]
    public class AlumnoApiControllerSteps
    {
        protected readonly IService<AlumnoDto> alumnoService;
        protected AlumnoDto alumno;

        [Given(@"Create AlumnDto")]
        public void GivenCreateAlumnDto()
        {
            alumno = new AlumnoDto("test", "test", "54354", DateTime.Parse("2015-11-16T16:00:00"));
        }
        
        [When(@"Pass AlumnDto to method Add")]
        public void WhenPassAlumnDtoToMethodAdd()
        {
            alumno = alumnoService.Add(alumno);
        }
        
        [Then(@"Compare the id")]
        public void ThenCompareTheId()
        {
            alumno.Id.Should().NotBe(0);
        }
    }
}
