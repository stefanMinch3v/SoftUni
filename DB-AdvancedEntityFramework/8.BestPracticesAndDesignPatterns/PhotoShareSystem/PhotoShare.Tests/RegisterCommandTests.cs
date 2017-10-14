namespace PhotoShare.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Service.Mocks;
    using System.Collections.Generic;
    using System.Data.Entity;
    using PhotoShare.Client.Core.Commands;
    using System;

    [TestClass]
    public class RegisterCommandTests
    {
        [TestMethod]
        // TODO: finish the implementation
        public void RegisterNewUserShouldSuccess()
        {
            //Arrange, Act, Assert
            //string[] commandParams = new string[] { "pesho", "mypass1", "mypass1", "user@u.com" };

            //Command registerCommand = new RegisterUserCommand(new UserServiceMock()); // create a mock which will be your own implementation inherited form user service
            //registerCommand.InsertData(commandParams);     
            //string result = registerCommand.Execute();
            // Assert.AreEqual($"User " + commandParams[0] + " was registered successfully!", /*result*/result);


            //var mockSet = new Mock<DbSet<User>>();

            //var mockContext = new Mock<PhotoShareContext>();
            //mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            //var service = new UserServiceMock(mockContext.Object);
            //service.RegisterUser("pesho", "mypass1", "mypass1", "user@u.com");

            //mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once()); // to check if the user it added only once
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());
            // it can be used mockSet.Verify(m => m.Add(It.Is<User>(u => u.Age == 20))) //this will throw an exception if the current user's age that you're trying to add is != 20


            var data = new List<User>
            {
                new User() { Username = "grigor", Password = "password13" },
                //new User() { Username = "pesho", Password = "mypass1" }
            };

            var mockSet = new Mock<DbSet<User>>().SetupData(data);
            var context = new Mock<PhotoShareContext>();
            context.Setup(m => m.Users).Returns(mockSet.Object);

            var service = new UserServiceMock(context.Object);
            //var result = service.GetUserByUsername("grigor");

            //var resultUser = result.Username;

            //Assert.AreEqual("grigor", resultUser);



            string[] commandParams = new string[] { "pesho", "mypass1", "mypass1", "user@u.com" };

            Command registerCommand = new RegisterUserCommand(service); // create a mock which will be your own implementation inherited form user service
            registerCommand.InsertData(commandParams);
            string finalResult = registerCommand.Execute();
            Assert.AreEqual($"User " + commandParams[0] + " was registered successfully!", /*result*/finalResult);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterUserWithTheSameUsernameShouldThrowException()
        {
            var data = new List<User>
            {
                new User() { Username = "grigor", Password = "password13" },
                new User() { Username = "pesho", Password = "mypass1" }
            };

            var mockSet = new Mock<DbSet<User>>().SetupData(data);
            var context = new Mock<PhotoShareContext>();
            context.Setup(m => m.Users).Returns(mockSet.Object);
            var service = new UserServiceMock(context.Object);

            string[] commandParams = new string[] { "pesho", "mypass1", "mypass1", "user@u.com" };

            Command registerCommand = new RegisterUserCommand(service); // create a mock which will be your own implementation inherited form user service
            registerCommand.InsertData(commandParams);
            string finalResult = registerCommand.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUserWithDifferentPasswordsShouldThrowException()
        {
            var data = new List<User>
            {
                new User() { Username = "grigor", Password = "password13" },
                new User() { Username = "ivan", Password = "mypass1" }
            };

            var mockSet = new Mock<DbSet<User>>().SetupData(data);
            var context = new Mock<PhotoShareContext>();
            context.Setup(m => m.Users).Returns(mockSet.Object);
            var service = new UserServiceMock(context.Object);

            string[] commandParams = new string[] { "pesho", "mypass123", "mypass1", "user@u.com" };

            Command registerCommand = new RegisterUserCommand(service); // create a mock which will be your own implementation inherited form user service
            registerCommand.InsertData(commandParams);
            string finalResult = registerCommand.Execute();
        }

        //TODO: mockups to the other services and create tests with moq
    }
}
