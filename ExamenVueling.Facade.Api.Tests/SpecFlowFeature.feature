Feature: AlumnoApiController
	Esta feature insertara un alumno a la base de datos.

@add
Scenario: Add alumn
	Given Create AlumnDto
	When Pass AlumnDto to method Add
	Then Compare the id
