using System.Runtime.Serialization;

namespace UserServiceLibrary.Exception
{
    /// <summary>
    /// Class discription not initialization user fields.
    /// </summary>
    public class NotInitializedFieldUserException : UserServiceException
    {
        /// <summary>
        /// Not initialization user fields exception.
        /// </summary>
        public NotInitializedFieldUserException()
        {
        }

        /// <summary>
        /// Not initialization user fields exception.
        /// </summary>
        /// <param name="message">Massage excepcion.</param>
        public NotInitializedFieldUserException(string message) : base(message)
        {
        }

        /// <summary>
        /// Not initialization user fields exception.
        /// </summary>
        /// <param name="message">Massage exception.</param>
        /// <param name="innerException">Gets the Exception instance that caused the current exception.</param>
        public NotInitializedFieldUserException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Not initialization user fields exception.
        /// </summary>
        /// <param name="info">Stores all the data needed to serialize or deserialize an object.</param>
        /// <param name="context">Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</param>
        protected NotInitializedFieldUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
