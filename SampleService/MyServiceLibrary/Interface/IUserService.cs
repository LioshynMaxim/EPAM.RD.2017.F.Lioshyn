using System;
using System.Collections.Generic;

namespace UserServiceLibrary.Interface
{
    /// <summary>
    /// Intarface for user's main function.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Add new user.
        /// </summary>
        /// <param name="user">User specimen.</param>
        void Add(User user);

        /// <summary>
        /// Delete new user.
        /// </summary>
        /// <param name="user">User specimen.</param>
        void Delete(User user);

        /// <summary>
        /// List user by predicate.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <returns>List of users.</returns>
        IEnumerable<User> SearchUserBySomeName(Predicate<User> predicate);
    }
}