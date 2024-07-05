using System.Runtime.Serialization;

namespace GA.UniCard.Application.CustomExceptions
{
    /// <summary>
    /// Exception thrown during compile time.
    /// </summary>
    [Serializable]
    public class CompileTImeException : Exception
    {
        public CompileTImeException()
        {
        }

        public CompileTImeException(string? message) : base(message)
        {
        }

        public CompileTImeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CompileTImeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
