using System;

namespace Companies.Core.ApplicationServices.Ports.Exceptions
{
    [Serializable]
    public class NotEnoughSpaceException : Exception
    {
        public NotEnoughSpaceException(string message) : base(message)
        {
        }
        
        public NotEnoughSpaceException()
        {
        }
    }
}
