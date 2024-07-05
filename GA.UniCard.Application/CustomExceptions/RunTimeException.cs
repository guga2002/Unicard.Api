using System.Runtime.Serialization;

namespace GA.UniCard.Application.CustomExceptions
{
    public class RunTimeException : Exception
    {
        public RunTimeException()
        {
        }

        public RunTimeException(string? message) : base(message)
        {
        }

        public RunTimeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RunTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
