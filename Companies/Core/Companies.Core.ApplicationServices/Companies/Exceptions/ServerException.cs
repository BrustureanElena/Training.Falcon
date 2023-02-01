using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Core.ApplicationServices.Companies.Exceptions
{
    [Serializable]
    public class ServerException : Exception
    {
        public ServerException(string message) : base(message)
        {
        }

        public ServerException()
        {
        }
    }
}
