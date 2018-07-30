using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Application.Services.Contracts
{
    public interface IPoliciesService<T>
    {
        List<T> GetListPoliciesByName(string name);
    }
}
