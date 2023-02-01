using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Core.ApplicationServices.Companies.Exceptions
{
    public class NotFoundRequestException : RequestException
    {
        public NotFoundRequestException()
        {
        }
        
        public NotFoundRequestException(string message) : base(message)
        {
        }
    }
}
