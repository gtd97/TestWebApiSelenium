using ExamenVueling.Application.Dto;
using ExamenVueling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Mappers
{
    public class MapperApplicationClients
    {

        public static ClientsEntity ClientDtoToClientEntity(ClientsDto clientDto)
        {
            ClientsEntity clientEntity = new ClientsEntity(clientDto.id, clientDto.nombre, clientDto.email, clientDto.role);
            return clientEntity;
        }

        public static List<ClientsEntity> ClientDtoToClientEntity(List<ClientsDto> listaClientsDto)
        {
            List<ClientsEntity> listaClientsEntity = new List<ClientsEntity>();

            foreach (var clientDto in listaClientsDto)
            {
                listaClientsEntity.Add(ClientDtoToClientEntity(clientDto));
            }

            return listaClientsEntity;
        }



        public static ClientsDto ClientEntityToClientDto(ClientsEntity clientEntity)
        {
            ClientsDto clientDto = new ClientsDto(clientEntity.id, clientEntity.nombre, clientEntity.email, clientEntity.role);
            return clientDto;
        }

        public static List<ClientsDto> ClientEntityToClientDto(List<ClientsEntity> listaClientsEntity)
        {
            List<ClientsDto> listaClientsDto = new List<ClientsDto>();

            foreach (var clientEntity in listaClientsEntity)
            {
                listaClientsDto.Add(ClientEntityToClientDto(clientEntity));
            }

            return listaClientsDto;
        }
    }
}
