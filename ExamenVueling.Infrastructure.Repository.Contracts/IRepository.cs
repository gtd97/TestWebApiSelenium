using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Infrastructure.Repository.Contracts
{
    public interface IRepository<T>
    {
        // En repository of work 
        T Add(T model);
        T Update(T model);
        List<T> GetAll();
        T GetById(int id);
        int Remove(int id); 
    }
}
