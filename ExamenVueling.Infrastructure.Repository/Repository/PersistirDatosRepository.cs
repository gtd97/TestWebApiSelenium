using ExamenVueling.Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExamenVueling.Infrastructure.Repository.Repository
{
    public class PersistirDatosRepository
    {
        public static void PersistirDatosClients(List<ClientsEntity> listaPolicies)
        {
            var DocXML = new XDocument(
                                    new XDeclaration("1.0", "utf-8", null),
                                    new XElement("Clients",
                                        from d in listaPolicies
                                        select new XElement("Client",
                                            new XAttribute("Id", d.id),
                                            new XElement("Nombre", d.nombre),
                                            new XElement("Email", d.email),
                                            new XElement("Role", d.role)
                                        )
                                    )
                                );

            DocXML.Save(ConfigurationManager.AppSettings.Get("XmlClients"));
        }


        public static void PersistirDatosPolicies(List<PoliciesEntity> listaPolicies)
        {
            var DocXML = new XDocument(
                                    new XDeclaration("1.0", "utf-8", null),
                                    new XElement("Clients",
                                        from d in listaPolicies
                                        select new XElement("Client",
                                            new XAttribute("Id", d.id),
                                            new XElement("AmountInsured", d.amountInsured),
                                            new XElement("Email", d.email),
                                            new XElement("InceptionDate", d.inceptionDate),
                                            new XElement("InstallmentPayment", d.installmentPayment),
                                            new XElement("ClientId", d.clientId)
                                        )
                                    )
                                );

            DocXML.Save(ConfigurationManager.AppSettings.Get("XmlPolicies"));
        }

    }
}
