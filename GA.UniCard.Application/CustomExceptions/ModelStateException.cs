using System.Runtime.Serialization;

namespace GA.UniCard.Application.CustomExceptions
{
    public class ModelStateException : Exception
    {
        public ModelStateException()
        {
        }

        public ModelStateException(string? message) : base(message)
        {
        }

        public ModelStateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ModelStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
