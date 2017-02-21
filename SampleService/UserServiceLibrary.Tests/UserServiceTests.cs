using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using UserServiceLibrary.Exception;
using Assert = NUnit.Framework.Assert;

namespace UserServiceLibrary.Tests
{
    /// <summary>
    /// Class for test User Library.
    /// </summary>
    [TestClass]
    public class UserServiceTests
    {
        #region Add
        /// <summary>
        /// Add null user.
        /// </summary>
        [Test]
        public void Add_NullUser_Exception()
        {
            //// Arrange  
            var userService = new UserService();
            //// Act & Assert
            Assert.Throws<ArgumentNullException>(() => { userService.Add(null); });
        }

        /// <summary>
        /// Add user with null last name.
        /// </summary>
        [Test]
        public void Add_UserWithEmptyOrNullLastNameField_Exception()
        {
            ////Arrange
            var userService = new UserService();
            User user = new User
            {
                FirstName = "Forest",
                LastName = null,
                DateOfBirth = DateTime.Now
            };
            ////Act & Assert
            Assert.Throws<NotInitializedFieldUserException>(() => { userService.Add(user); });
        }

        /// <summary>
        /// Add user with null first name.
        /// </summary>
        [Test]
        public void Add_UserWithEmptyOrNullFirstNameField_Exception()
        {
            //// Arrange
            var userService = new UserService();
            User user = new User
            {
                FirstName = null,
                LastName = "Gamp",
                DateOfBirth = null
            };
            ////Act & Assert
            Assert.Throws<NotInitializedFieldUserException>(() => { userService.Add(user); });
        }

        /// <summary>
        /// Add user with non birth day.
        /// </summary>
        [Test]
        public void Add_UserWithEmptyOrNullDateOfBirthField_Exception()
        {
            //// Arrange
            var userService = new UserService();
            User user = new User
            {
                FirstName = "Forest",
                LastName = "Gamp"
            };
            ////Act & Assert
            Assert.Throws<NotInitializedFieldUserException>(() => { userService.Add(user); });
        }

        /// <summary>
        /// Add user with two equal users.
        /// </summary>
        [Test]
        public void Add_TwoSimilarUsersWithEqualityComparer_ExceptionThrown()
        {
            //// Arrange
            var userService = new UserService();
            User user1 = new User
            {
                FirstName = "Forest",
                LastName = "Gamp",
                DateOfBirth = DateTime.Now
            };

            User user2 = new User
            {
                FirstName = "Forest",
                LastName = "Gamp",
                DateOfBirth = DateTime.Now
            };
            ////Act
            userService.Add(user1);
            //// Assert
            Assert.Throws<ExistUserException>(() => { userService.Add(user2); });
        }

        /// <summary>
        /// Test with exception about 2 equals users.
        /// </summary>
        [Test]
        public void Add_TwoAddedOneUser_Exception()
        {
            //// Arrange
            var userService = new UserService();
            User user = new User
            {
                FirstName = "Forest",
                LastName = "Gamp",
                DateOfBirth = DateTime.Now
            };
            ////Act
            userService.Add(user);
            //// Assert
            Assert.Throws<ExistUserException>(() => { userService.Add(user); });
        }

        /// <summary>
        /// Test with success user.
        /// </summary>
        [Test]
        public void Add_Seccess_User()
        {
            //// Arrange  
            var s = new UserService();
            var user = new User
            {
                FirstName = "Forest",
                LastName = "Gamp",
                DateOfBirth = DateTime.Now
            };
            //// Act 
            s.Add(user);
            //// Assert
            var actual = s.SearchUserBySomeName(u => u.FirstName == user.FirstName).FirstOrDefault();
            Assert.AreEqual(user.FirstName, actual?.FirstName);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete null user.
        /// </summary>
        [Test]
        public void Delete_NullUser_Exception()
        {
            //// Arrange  
            var service = new UserService();
            //// Act & Assert 
            Assert.Throws<ArgumentNullException>(() => service.Delete(null));
        }

        /// <summary>
        /// Delete not exist user.
        /// </summary>
        [Test]
        public void Delete_UnexistingUser_Exception()
        {
            //// Arrange  
            var service = new UserService(o => o.GetHashCode());
            var user = new User
            {
                Id = 123,
                FirstName = "Forest",
                LastName = "Gamp",
                DateOfBirth = DateTime.Today
            };
            //// Act & Assert 
            Assert.Throws<DoesNotUserException>(() => service.Delete(user));
        }

        /// <summary>
        /// Delete not valid user.
        /// </summary>
        [Test]
        public void Delete_NotValidUser_Exception()
        {
            //// Arrange  
            var service = new UserService();
            var user = new User();

            //// Act & Assert 
            Assert.Throws<DoesNotUserException>(() => service.Delete(user));
        }

        /// <summary>
        /// Add and delete added users from other users.
        /// </summary>
        [Test]
        public void Delete_User_Success()
        {
            //// Arrange  
            var service = new UserService();
            var user = new User
            {
                FirstName = "Forest",
                LastName = "Gamp",
                DateOfBirth = DateTime.Today
            };
            service.Add(user);
            var user1 = new User
            {
                FirstName = "Melle",
                LastName = "Famer",
                DateOfBirth = DateTime.Today
            };
            service.Add(user1);
            user = service.SearchUserBySomeName(u => u.FirstName == "Forest").FirstOrDefault();
            ////Act
            service.Delete(user); 
            ////Assert
            var actual = service.SearchUserBySomeName(u => u.FirstName == "Forest").FirstOrDefault();
            Assert.IsNull(actual);
        }
        #endregion
    }
}