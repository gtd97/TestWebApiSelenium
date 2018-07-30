using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVueling.Common.Layer
{
    public class VuelingExceptions: Exception
    {
        public VuelingExceptions()
        {
        }

        public VuelingExceptions(string message): base(message)
        {
        }

        public VuelingExceptions(string message, Exception inner): base(message, inner)
        {
        }
    }
}
