using ExamenVueling.Common.Layer;
using ExamenVueling.Domain.Models;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Infrastructure.Repository.Mappers;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExamenVueling.Infrastructure.Repository.Repository
{
    public class ClientsRepository : IRepositoryClients<ClientsEntity>
    {
        //private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        XDocument xmlClients;

        public List<ClientsEntity> GetAll()
        {
            xmlClients = XDocument.Load(ConfigurationManager.AppSettings.Get("XmlClients"));
            List<ClientsEntity> listaClients = new List<ClientsEntity>();
            
            var clients = from clientes in xmlClients.Descendants("Clients")
                          from client in clientes.Elements("Client")
                          select new { id = client.Attribute("Id").Value, nombre = client.Element("Nombre").FirstNode, email = client.Element("Email").FirstNode, role = client.Element("Role").FirstNode };

            foreach (var client in clients)
            {
                ClientsEntity clientNew = new ClientsEntity(client.id, client.nombre.ToString(), client.email.ToString(), client.role.ToString());
                listaClients.Add(clientNew);
            }

            return listaClients;
        }

        public ClientsEntity GetById(string id)
        {
            xmlClients = XDocument.Load(ConfigurationManager.AppSettings.Get("XmlClients"));

            var clients = from clientes in xmlClients.Descendants("Clients")
                          from client in clientes.Elements("Client")
                          where client.Attribute("Id").Value == id
                          select new { id = client.Attribute("Id").Value, nombre = client.Element("Nombre").FirstNode, email = client.Element("Email").FirstNode, role = client.Element("Role").FirstNode };

            ClientsEntity clientFindById = null;

            foreach (var client in clients)
            {
                clientFindById = new ClientsEntity(client.id, client.nombre.ToString(), client.email.ToString(), client.role.ToString());
            }

            return clientFindById;
        }

        public ClientsEntity GetByName(string name)
        {
            xmlClients = XDocument.Load(ConfigurationManager.AppSettings.Get("XmlClients"));

            var clients = from clientes in xmlClients.Descendants("Clients")
                          from client in clientes.Elements("Client")
                          where client.Element("Nombre").Value == name
                          select new { id = client.Attribute("Id").Value, nombre = client.Element("Nombre").FirstNode, email = client.Element("Email").FirstNode, role = client.Element("Role").FirstNode };

            ClientsEntity clientFindByName = null;

            foreach (var client in clients)
            {
                clientFindByName = new ClientsEntity(client.id, client.nombre.ToString(), client.email.ToString(), client.role.ToString());
            }

            return clientFindByName;
        }
    }
}
