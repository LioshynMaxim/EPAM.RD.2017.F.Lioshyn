using System;
using System.Collections.Generic;
using System.Linq;
using UserServiceLibrary.Exception;
using UserServiceLibrary.Interface;
using static System.String;

namespace UserServiceLibrary
{
    /// <summary>
    /// User interface class.
    /// </summary>
    public class UserService : IUserService
    {
        #region .ctor

        /// <summary>
        /// Default ctor.
        /// </summary>
        public UserService()
        {
            this.IdUser = o => o.GetHashCode();
            this.Users = new HashSet<User>();
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="idUser">Id user.</param>
        public UserService(Func<object, int> idUser = null)
        {
            this.Users = new HashSet<User>();
            this.IdUser = idUser;
        }

        #endregion

        #region fields

        private Func<object, int> IdUser { get; }

        private HashSet<User> Users { get; }

        #endregion

        #region Main function

        /// <summary>
        /// Add new user.
        /// </summary>
        /// <param name="user">User specimen.</param>
        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        /// <exception cref="NotInitializedFieldUserException">Not initialized some field.</exception>
        /// <exception cref="ExistUserException">This user is exist.</exception>
        public void Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException($"{nameof(user)} is null");
            }

            if (IsNullOrEmpty(user.FirstName) || IsNullOrEmpty(user.LastName) || user.DateOfBirth == null)
            {
                throw new NotInitializedFieldUserException($"{nameof(user)} is not initialized some (all) fields.");
            }

            if (!this.CheckUser(user) || this.Users.Contains(user))
            {
                throw new ExistUserException($"{nameof(user)} is exist.");
            }

            user.Id = this.IdUser(user);
            this.Users.Add(user);
        }

        /// <summary>
        /// Delete new user.
        /// </summary>
        /// <param name="user">User specimen.</param>
        /// <exception cref="DoesNotUserException">User is exist.</exception>
        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        public void Delete(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException($"{nameof(user)} is null");
            }

            if (this.CheckUser(user))
            {
                throw new DoesNotUserException($"{nameof(user)} is not exist.");
            }

            this.Users.Remove(user);
        }

        /// <summary>
        /// List user by predicate.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        /// <returns>List of users.</returns>
        public IEnumerable<User> SearchUserBySomeName(Predicate<User> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} is null");
            }

            return this.Users.Where(u => predicate(u));
        }

        #endregion

        #region Auximilary
        /// <summary>
        /// Check user in DB.
        /// </summary>
        /// <param name="user">User specimen.</param>
        /// <returns>True, if user in DB, false in other.</returns>
        private bool CheckUser(User user)
            => this.Users.FirstOrDefault(u => u.FirstName == user.FirstName && u.LastName == user.LastName) == default(User);
        #endregion
    }
}
