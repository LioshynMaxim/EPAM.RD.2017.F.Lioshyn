using System.Runtime.Serialization;

namespace UserServiceLibrary.Exception
{
    /// <summary>
    /// Discription user exception class.
    /// </summary>

    public class UserServiceException : System.Exception
    {
        /// <summary>
        /// User service exception.
        /// </summary>

        public UserServiceException()
        {
        }

        /// <summary>
        /// User service exception.
        /// </summary>
        /// <param name="message">Massage exception.</param>

        public UserServiceException(string message) : base(message)
        {
        }

        /// <summary>
        /// User service exception.
        /// </summary>
        /// <param name="message">Massage exception.</param>
        /// <param name="innerException">Gets the Exception instance that caused the current exception.</param>

        public UserServiceException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// User service exception.
        /// </summary>
        /// <param name="info">Stores all the data needed to serialize or deserialize an object.</param>
        /// <param name="context">Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</param>

        protected UserServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
