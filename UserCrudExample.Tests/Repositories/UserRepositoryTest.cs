using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using UserCrudExample.Repositories;
using UserCrudExample.Tests.Config;

namespace UserCrudExample.Tests.Repositories
{
    /// <summary>
    /// UserCrudExample
    /// Author: Fernando Concepción Gutiérrez
    /// http://www.fconcepcion.com
    /// 
    /// Test to repository
    /// </summary>
    [TestClass]
    public class UserRepositoryTest
    {
        private IUserRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = AutofacConfig.GetContainerConfigured().Resolve<IUserRepository>();
        }

        [TestMethod]
        public void GetAllUsers()
        {
            // Arrange
            var totalElementsExpected = 2;
            var nameExpected = "Fernando";

            // Act
            var all = _repository.GetAllUsers();

            // Assert
            Assert.IsNotNull(all);
            Assert.AreEqual(totalElementsExpected, all.Count);
            Assert.IsTrue(all.Any(x => x.Name == nameExpected));
        }

        [TestMethod]
        public void GetUser()
        {
            // Arrange
            var elementIndex = 1;
            var nameExpected = "Fernando";

            // Act
            var user = _repository.GetUser(elementIndex);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreSame(nameExpected, user.Name);
        }

        [TestMethod]
        public void RemoveUser()
        {
            // Arrange
            var elementIndex = 1;
            var totalElementsExpected = 1;

            // Act
            _repository.RemoveUser(elementIndex);
            var all = _repository.GetAllUsers();

            // Assert
            Assert.AreEqual(totalElementsExpected, all.Count);
        }

        [TestMethod]
        public void AddUser()
        {
            // Arrange
            var name = "Example name";
            var birthdate = new DateTime(2000, 1, 1);
            var totalElementsExpected = 3;

            // Act
            var insertedUser = _repository.AddUser(name, birthdate);
            var all = _repository.GetAllUsers();

            // Assert
            Assert.IsNotNull(insertedUser);
            Assert.IsNotNull(all);
            Assert.AreEqual(totalElementsExpected, all.Count);
            Assert.IsTrue(all.Any(x => x.Name == name));
        }

        [TestMethod]
        public void EditUser()
        {
            // Arrange
            var newName = "Edited name";
            var oldName = "Fernando";
            var userId = 1;
            var birthdate = new DateTime(2000, 1, 1);
            var totalElementsExpected = 2;

            // Act
            var editedUser = _repository.EditUser(userId, newName, birthdate);
            var all = _repository.GetAllUsers();

            // Assert
            Assert.IsNotNull(editedUser);
            Assert.IsNotNull(all);
            Assert.AreEqual(totalElementsExpected, all.Count);
            Assert.IsTrue(all.Any(x => x.Name == newName));
            Assert.IsFalse(all.Any(x => x.Name == oldName));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _repository.Dispose();
        }
    }
}
