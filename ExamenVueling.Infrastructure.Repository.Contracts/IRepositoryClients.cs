using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Infrastructure.Repository.Contracts
{
    public interface IRepositoryClients<T>
    {
        List<T> GetAll();
        T GetById(string id);
        T GetByName(string name);
    }
}
