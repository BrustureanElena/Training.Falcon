using System;

namespace Companies.Core.ApplicationServices.Ports.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException()
        {
        }
    }
}
