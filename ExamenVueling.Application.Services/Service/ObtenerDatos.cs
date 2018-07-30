using ExamenVueling.Application.Dto;
using ExamenVueling.Application.Services.Mappers;
using ExamenVueling.Common.Layer;
using ExamenVueling.Domain.Models;
using ExamenVueling.Infrastructure.Repository.Contracts;
using ExamenVueling.Infrastructure.Repository.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Service
{
    public class ObtenerDatos
    {
        public async void ObtenerClients(string url)
        {
            HttpClient httpClients = new HttpClient();
            List<ClientsEntity> listado = new List<ClientsEntity>();

            try
            {
                HttpResponseMessage response = httpClients.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = await response.Content.ReadAsStringAsync();
                    DataSet deserialized = JsonConvert.DeserializeObject<DataSet>(JsonString);
                    DataTable dataTable = deserialized.Tables["Clients"];

                    foreach (DataRow row in dataTable.Rows)
                    {
                        ClientsDto clientDto = new ClientsDto(row["id"].ToString(), row["name"].ToString(), row["email"].ToString(), row["role"].ToString());
                        listado.Add(MapperApplicationClients.ClientDtoToClientEntity(clientDto));
                    }

                    PersistirDatosRepository.PersistirDatosClients(listado);
                }
            }
            catch (VuelingExceptions ex)
            {
                throw ex;
            }
        }



        public async void ObtenerPolicies(string url)
        {
            HttpClient httpClients = new HttpClient();
            List<PoliciesEntity> listado;

            try
            {
                HttpResponseMessage response = httpClients.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var JsonString = await response.Content.ReadAsStringAsync();
                    DataSet deserialized = JsonConvert.DeserializeObject<DataSet>(JsonString);
                    DataTable dataTablePolicies = deserialized.Tables["Policies"];

                    listado = new List<PoliciesEntity>();
                    foreach (DataRow rowPolicies in dataTablePolicies.Rows)
                    {
                        PoliciesDto policiesDto = new PoliciesDto(rowPolicies["id"].ToString(), Double.Parse(rowPolicies["amountInsured"].ToString()), rowPolicies["email"].ToString(), DateTime.Parse(rowPolicies["inceptionDate"].ToString()), Boolean.Parse(rowPolicies["installmentPayment"].ToString()), rowPolicies["clientId"].ToString());
                        listado.Add(MapperApplicationPolicies.PoliciesDtoToPoliciesEntity(policiesDto));
                    }

                    PersistirDatosRepository.PersistirDatosPolicies(listado);
                }
            }
            catch (VuelingExceptions ex)
            {
                throw ex;
            }
        }



    }
}
