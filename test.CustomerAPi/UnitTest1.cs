using Customer.DTO.Models;
using CustomerAPi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace test.CustomerAPi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_GetUsers_returnOk()
        {
            var mockRepo = new Mock<AdminController>();            

            Assert.IsNotNull(mockRepo.Object.GetUsers());
            Assert.AreEqual(200, mockRepo.Object.GetUsers());

        }
        [TestMethod]
        public void Test_CreateNewUser_returnOk()
        {
            var mockRepo = new Mock<AdminController>();
            var mockData = new Mock<UserRequest>();

            Assert.IsNotNull(mockRepo.Object.CreateNewUser(mockData.Object));
            Assert.AreEqual(200, mockRepo.Object.CreateNewUser(mockData.Object));

        }
        [TestMethod]
        public void Test_UpdateUser_returnOk()
        {
            var mockRepo = new Mock<AdminController>();
            var mockData = new Mock<UserRequest>();

            Assert.IsNotNull(mockRepo.Object.UpdateUser(mockData.Object));
            Assert.AreEqual(200, mockRepo.Object.UpdateUser(mockData.Object));

        }        
    }
}