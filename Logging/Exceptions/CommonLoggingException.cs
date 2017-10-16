using System;
using System.Runtime.Serialization;

namespace WinService.Logging.Exceptions
{
    public class CommonLoggingException : Exception
    {
        public CommonLoggingException() : base()
        {
        }

        public CommonLoggingException(string message) : base(message)
        {
        }

        public CommonLoggingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CommonLoggingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
