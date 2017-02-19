using System;

namespace UserServiceLibrary
{
    /// <summary>
    /// Class for work with entity user.
    /// </summary>

    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
