using System.Runtime.Serialization;

namespace UserServiceLibrary.Exception
{
    /// <summary>
    /// Class discription not exist user.
    /// </summary>
    public class DoesNotUserException : UserServiceException
    {
        /// <summary>
        /// User not exist exception.
        /// </summary>
        public DoesNotUserException()
        {
        }

        /// <summary>
        /// User not exist exception.
        /// </summary>
        /// <param name="message">Massage exception.</param>
        public DoesNotUserException(string message) : base(message)
        {
        }

        /// <summary>
        /// User not exist exception.
        /// </summary>
        /// <param name="message">Massage exception.</param>
        /// <param name="innerException">Gets the Exception instance that caused the current exception.</param>
        public DoesNotUserException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// User not exist exception.
        /// </summary>
        /// <param name="info">Stores all the data needed to serialize or deserialize an object.</param>
        /// <param name="context">Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</param>
        protected DoesNotUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
