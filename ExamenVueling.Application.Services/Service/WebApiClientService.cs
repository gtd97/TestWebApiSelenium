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
    public class WebApiClientService : IClientsService<ClientsDto>
    {
        private readonly IRepositoryClients<ClientsEntity> iRepositoryClients;

        public WebApiClientService() : this(new ClientsRepository())
        {
        }

        public WebApiClientService(ClientsRepository clientsRepository)
        {
            this.iRepositoryClients = clientsRepository;
        }


        public List<ClientsDto> GetAll()
        {
            List<ClientsEntity> lista = iRepositoryClients.GetAll();
            return MapperApplicationClients.ClientEntityToClientDto(lista);
        }

        public ClientsDto GetById(string id)
        {
            ClientsEntity client = iRepositoryClients.GetById(id);
            return MapperApplicationClients.ClientEntityToClientDto(client);
        }

        public ClientsDto GetByName(string name)
        {
            ClientsEntity client = iRepositoryClients.GetByName(name);
            return MapperApplicationClients.ClientEntityToClientDto(client);
        }

    }
}
