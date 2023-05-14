using System;

namespace Services.API.Exceptions
{
    public class CallApiException : Exception
    {
        public CallApiException(string message) : base(message)
        {
        }

        public CallApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}