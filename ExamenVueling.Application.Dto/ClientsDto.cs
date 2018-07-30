using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Dto
{
    public class ClientsDto
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string role { get; set; }

        public ClientsDto() { }

        public ClientsDto(string id, string nombre, string email, string role)
        {
            this.id = id;
            this.nombre = nombre;
            this.email = email;
            this.role = role;
        }

    }
}
