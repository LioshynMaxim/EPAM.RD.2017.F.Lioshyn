using System;

namespace UserServiceLibrary
{
    /// <summary>
    /// Class for work with entity user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// User id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User birth date.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
    }
}
