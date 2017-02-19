using System.Runtime.Serialization;

namespace UserServiceLibrary.Exception
{
    /// <summary>
    /// Class discription exist user.
    /// </summary>

    public class ExistUserException : UserServiceException
    {
        /// <summary>
        /// User exist exception.
        /// </summary>

        public ExistUserException()
        {
        }

        /// <summary>
        /// User exist exception.
        /// </summary>
        /// <param name="message">Massage exception.</param>

        public ExistUserException(string message) : base(message)
        {
        }

        /// <summary>
        /// User exist exception.
        /// </summary>
        /// <param name="message">Massage exception.</param>
        /// <param name="innerException">Gets the Exception instance that caused the current exception.</param>

        public ExistUserException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// User exist exception.
        /// </summary>
        /// <param name="info">Stores all the data needed to serialize or deserialize an object.</param>
        /// <param name="context">Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</param>

        protected ExistUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
