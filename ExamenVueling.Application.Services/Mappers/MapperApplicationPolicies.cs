using ExamenVueling.Application.Dto;
using ExamenVueling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Mappers
{
    public class MapperApplicationPolicies
    {
        public static PoliciesEntity PoliciesDtoToPoliciesEntity(PoliciesDto policiesDto)
        {
            PoliciesEntity policiesEntity = new PoliciesEntity(policiesDto.id, policiesDto.amountInsured, policiesDto.email, policiesDto.inceptionDate, policiesDto.installmentPayment, policiesDto.clientId);
            return policiesEntity;
        }


        public static List<PoliciesEntity> PoliciesDtoToPoliciesEntity(List<PoliciesDto> listaPoliciesDto)
        {
            List<PoliciesEntity> listaPoliciesEntity = new List<PoliciesEntity>();

            foreach (var policies in listaPoliciesDto)
            {
                listaPoliciesEntity.Add(PoliciesDtoToPoliciesEntity(policies));
            }

            return listaPoliciesEntity;
        }
        

        public static PoliciesDto PoliciesEntityToPoliciesDto(PoliciesEntity policiesEntity)
        {
            PoliciesDto policiesDto = new PoliciesDto(policiesEntity.id, policiesEntity.amountInsured, policiesEntity.email, policiesEntity.inceptionDate, policiesEntity.installmentPayment, policiesEntity.clientId);
            return policiesDto;
        }


        public static List<PoliciesDto> PoliciesEntityToPoliciesDto(List<PoliciesEntity> listaPoliciesEntity)
        {
            List<PoliciesDto> listaPoliciesDto = new List<PoliciesDto>();

            foreach (var policies in listaPoliciesEntity)
            {
                listaPoliciesDto.Add(PoliciesEntityToPoliciesDto(policies));
            }

            return listaPoliciesDto;
        }
    }
}
