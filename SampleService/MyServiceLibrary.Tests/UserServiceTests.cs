using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserServiceLibrary.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullUser_ExceptionThrown()
        {
        }
    }
}
