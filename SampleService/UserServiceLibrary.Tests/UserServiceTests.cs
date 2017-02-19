using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using UserServiceLibrary.Exception;
using Assert = NUnit.Framework.Assert;


namespace UserServiceLibrary.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void Add_NullUser_Exception()
        {
            // Arrange  
            var userService = new UserService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => { userService.Add(null); });
            
        }

        [Test]
        public void Add_UserWithEmptyOrNullLastNameField_Exception()
        {
            // Arrange
            var userService = new UserService();
            User user = new User
            {
                FirstName = "Forest",
                LastName = null,
                DateOfBirth = DateTime.Now
            };

            //Act & Assert
            Assert.Throws<NotInitializedFieldUserException>(() => { userService.Add(user); });
        }

        [Test]
        public void Add_UserWithEmptyOrNullFirstNameField_Exception()
        {
            // Arrange
            var userService = new UserService();
            User user = new User
            {
                FirstName = "Forest",
                LastName = "Gamp",
                DateOfBirth = null
            };

            //Act & Assert
            Assert.Throws<NotInitializedFieldUserException>(() => { userService.Add(user); });
        }

        [Test]
        public void Add_UserWithEmptyOrNullDateOfBirthField_Exception()
        {
            // Arrange
            var userService = new UserService();
            User user = new User
            {
                LastName = "Gamp",
                DateOfBirth = DateTime.Now
            };

            //Act & Assert
            Assert.Throws<NotInitializedFieldUserException>(() => { userService.Add(user); });
        }

        [Test]
        public void Add_TwoSimilarUsersWithEqualityComparer_ExceptionThrown()
        {
            // Arrange
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

            //Act
            userService.Add(user1);

            // Assert
            Assert.Throws<ExistUserException>(() => { userService.Add(user2); });
        }

        [Test]
        public void Add_TwoAddedOneUser_Exception()
        {
            // Arrange
            var userService = new UserService();
            User user = new User
            {
                FirstName = "Forest",
                LastName = "Gamp",
                DateOfBirth = DateTime.Now
            };
            
            //Act
            userService.Add(user);

            // Assert
            Assert.Throws<ExistUserException>(() => { userService.Add(user); });
        }


    }
}