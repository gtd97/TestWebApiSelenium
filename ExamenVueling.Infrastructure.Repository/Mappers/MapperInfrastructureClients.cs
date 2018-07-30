using ExamenVueling.Application.Dto;
using ExamenVueling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Infrastructure.Repository.Mappers
{
    public class MapperInfrastructureClients
    { 
        public static ClientsEntity ClientDataModelToClientEntity(ClientsDto model)
        {
            ClientsEntity clientEntity = new ClientsEntity(model.id, model.nombre, model.email, model.role);

            return clientEntity;
        }

        public static List<ClientsEntity> ClientDataModelToClientEntity(List<ClientsDto> listaClientsDataModel)
        {
            List<ClientsEntity> listaClientsEntity = new List<ClientsEntity>();

            foreach (var client in listaClientsDataModel)
            {
                listaClientsEntity.Add(ClientDataModelToClientEntity(client));
            }

            return listaClientsEntity;
        }

    }
}
