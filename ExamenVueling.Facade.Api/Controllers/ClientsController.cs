using ExamenVueling.Application.Dto;
using ExamenVueling.Application.Services.Contracts;
using ExamenVueling.Application.Services.Service;
using ExamenVueling.Common.Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamenVueling.Facade.Api.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly IClientsService<ClientsDto> clientsService;

        public ClientsController() : this(new WebApiClientService())
        {
        }

        public ClientsController(WebApiClientService clientsService)
        {
            this.clientsService = clientsService;
        }


        // GET: api/Clients
        public IHttpActionResult Get()
        {
            try
            {
                List<ClientsDto> listaClients = clientsService.GetAll();

                if (listaClients != null)
                {
                    return Ok(listaClients);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (VuelingExceptions ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // GET api/Clients/id/{id}
        [Route("api/Clients/id/{id}")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                ClientsDto client = clientsService.GetById(id);

                if (client != null)
                {
                    return Ok(client);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (VuelingExceptions ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }


        // GET api/Clients/name/{name}
        [Route("api/Clients/name/{name}")]
        public IHttpActionResult GetByName(string name)
        {
            try
            {
                ClientsDto client = clientsService.GetByName(name);

                if (client != null)
                {
                    return Ok(client);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (VuelingExceptions ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
        
    }
}
