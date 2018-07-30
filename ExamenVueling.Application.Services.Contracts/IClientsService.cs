using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Contracts
{
    public interface IClientsService<T>
    {
        List<T> GetAll();
        T GetByName(string name);
        T GetById(string id);
    }
}
