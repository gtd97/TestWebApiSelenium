using ExamenVueling.Application.Dto;
using ExamenVueling.Application.Services.Contracts;
using ExamenVueling.Application.Services.Mappers;
using ExamenVueling.Domain.Models;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Infrastructure.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Service
{
    public class WebApiPoliciesService: IPoliciesService<PoliciesDto>
    {
        private readonly IRepositoryPolicies<PoliciesEntity> iRepositoryPolicies;

        public WebApiPoliciesService() : this(new PoliciesRepository())
        {
        }

        public WebApiPoliciesService(PoliciesRepository policiesRepository)
        {
            this.iRepositoryPolicies = policiesRepository;
        }


        public List<PoliciesDto> GetListPoliciesByName(string name)
        {
            List<PoliciesEntity> listPolicies = new List<PoliciesEntity>();
            listPolicies = iRepositoryPolicies.GetListPoliciesByName(name);

            return MapperApplicationPolicies.PoliciesEntityToPoliciesDto(listPolicies);
        }
    }
}
