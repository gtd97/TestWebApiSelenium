using ExamenVueling.Application.Dto;
using ExamenVueling.Application.Services.Contracts;
using ExamenVueling.Application.Services.Service;
using ExamenVueling.Common.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamenVueling.Facade.Api.Controllers
{
    public class PoliciesController : ApiController
    {
        private readonly IPoliciesService<PoliciesDto> policiesService;

        public PoliciesController() : this(new WebApiPoliciesService())
        {
        }

        public PoliciesController(WebApiPoliciesService policiesService)
        {
            this.policiesService = policiesService;
        }


        // GET api/Policies/ListByNameClient/{name}
        [Route("api/Policies/ListByNameClient/{name}")]
        public IHttpActionResult GetListPoliciesByName(string name)
        {
            try
            {
                List<PoliciesDto> listaPolicies = policiesService.GetListPoliciesByName(name);

                if (listaPolicies != null)
                {
                    return Ok(listaPolicies);
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
