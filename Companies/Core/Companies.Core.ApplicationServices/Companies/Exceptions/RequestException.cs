using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Core.ApplicationServices.Companies.Exceptions
{
    [Serializable]
    public class RequestException : Exception
    {
        public RequestException(string message) : base(message)
        {
        }

        public RequestException()
        {
        }
    }
}
