using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using APIDemo;

namespace APITests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void VerifyListOfUsers()
        {
            var demo = new APIService<ListOfUsersDTO>();
            var user = demo.GetUsers("api/users?page=2");
            Assert.AreEqual(2, user.Page);
            Assert.AreEqual("Michael", user.Data[0].first_name);
        }

        [TestMethod]
        public void CreateNewUser()
        {
            string payload = @"{
                                ""name"": ""Mike"",
                                ""job"": ""Team leader""
                               }";
            var demo = new APIService<CreateUserDTO>();
            var user = demo.CreateUser("api/users", payload);
            

            Assert.AreEqual("Mike", user.Name);
            Assert.AreEqual("Team leader", user.Job);
        }
    }
}

