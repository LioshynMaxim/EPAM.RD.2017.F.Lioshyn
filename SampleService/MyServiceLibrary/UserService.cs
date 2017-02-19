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
        #region fields

        private IEqualityComparer<User> UserEquality { get; }
        private Func<object, int> IdUser { get; }
        private HashSet<User> Users { get; set; }

        #endregion

        #region .ctor

        /// <summary>
        /// Default ctor.
        /// </summary>

        public UserService()
        {
            IdUser = o => o.GetHashCode();
            Users = new HashSet<User>();
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="idUser">Id user.</param>
        /// <param name="userEquality">Equality user compere.</param>

        public UserService(Func<object, int> idUser = null, IEqualityComparer<User> userEquality = null)
        {
            Users = new HashSet<User>();
            IdUser = idUser;
            UserEquality = userEquality ?? EqualityComparer<User>.Default;
        }

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
                throw new ArgumentNullException($"{nameof(user)} is null");
            
            if (IsNullOrEmpty(user.FirstName) ||  IsNullOrEmpty(user.LastName) || user.DateOfBirth == null)
                throw new NotInitializedFieldUserException($"{nameof(user)} is not initialized some (all) fields.");

            if (!CheckUser(user) || Users.Contains(user))
                throw new ExistUserException($"{nameof(user)} is exist.");
            

            user.Id = IdUser(user);
            Users.Add(user);
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
                throw new ArgumentNullException($"{nameof(user)} is null");

            if (CheckUser(user))
                throw new DoesNotUserException($"{nameof(user)} is not exist.");
        }

        /// <summary>
        /// List user by predicate.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        /// <returns>List of users.</returns>

        public IEnumerable<User> SearchUserBySomeName(Predicate<User> predicate)
        {
            if(predicate == null)
                throw new ArgumentNullException($"{nameof(predicate)} is null");

            return Users.Where(u => predicate(u));
        }

        #endregion

        #region Auximilary

        /// <summary>
        /// Check user in DB.
        /// </summary>
        /// <param name="user">User specimen.</param>
        /// <returns>True, if user in DB, false in other.</returns>

        private bool CheckUser(User user)
            => Users.FirstOrDefault(u => u.FirstName == user.FirstName && u.LastName == user.LastName) == default(User);

        #endregion
    }
}
