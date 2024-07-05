using System.Runtime.Serialization;

namespace GA.UniCard.Application.CustomExceptions
{
    public class UniCardGeneralException : Exception
    {
        public UniCardGeneralException()
        {
        }

        public UniCardGeneralException(string? message) : base(message)
        {
        }

        public UniCardGeneralException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UniCardGeneralException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
