using ExamenVueling.Domain.Models;
using ExamenVueling.Infrastructure.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExamenVueling.Infrastructure.Repository.Repository
{
    public class PoliciesRepository : IRepositoryPolicies<PoliciesEntity>
    {

        public List<PoliciesEntity> GetListPoliciesByName(string name)
        {
            List<PoliciesEntity> listaPolizas;
            XDocument xmlClients = XDocument.Load(ConfigurationManager.AppSettings.Get("XmlClients"));
            XDocument xmlPolicies = XDocument.Load(ConfigurationManager.AppSettings.Get("XmlPolicies"));

            string clientId = (from clientes in xmlClients.Descendants("Clients").Elements("Client")
                               where clientes.Element("Nombre").Value == "Britney"
                               select clientes.Attribute("Id").Value).First().ToString();


            var policies = from policie in xmlPolicies.Descendants("Clients").Elements("Client")
                           where policie.Element("ClientId").Value == clientId
                           select new
                           {
                               id = policie.Attribute("Id").Value,
                               amountInsured = policie.Element("AmountInsured").Value,
                               email = policie.Element("Email").Value,
                               inceptionDate = policie.Element("InceptionDate").Value,
                               installmentPayment = policie.Element("InstallmentPayment").Value,
                               clientId = policie.Element("ClientId").Value,
                           };


            listaPolizas = new List<PoliciesEntity>();

            foreach (var policie in policies)
            {
                PoliciesEntity poliza = new PoliciesEntity(policie.id.ToString(), Double.Parse(policie.amountInsured.ToString()), policie.email.ToString(), DateTime.Parse(policie.inceptionDate.ToString()), Boolean.Parse(policie.installmentPayment.ToString()), policie.clientId.ToString());

                listaPolizas.Add(poliza);
            }

            return listaPolizas;
        }

    }
}