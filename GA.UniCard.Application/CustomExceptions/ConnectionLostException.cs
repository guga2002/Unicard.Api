using System.Runtime.Serialization;

namespace GA.UniCard.Application.CustomExceptions
{
    public class ConnectionLostException : Exception
    {
        public ConnectionLostException()
        {
        }

        public ConnectionLostException(string? message) : base(message)
        {
        }

        public ConnectionLostException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ConnectionLostException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
