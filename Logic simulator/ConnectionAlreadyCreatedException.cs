using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_simulator
{
    public class ConnectionAlreadyCreatedException : Exception
    {
        public ConnectionAlreadyCreatedException(string message) : base(message)
        {
        }
    }
}
