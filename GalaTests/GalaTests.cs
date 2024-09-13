using Gala;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GalaTests
{
    [TestClass]
    public class GalaTests
    {

        [TestMethod]
        public void TestAuthorizeUserIncorrec()
        {
            string login = "Admin1!";
            string incorrectPassword = "incorrectPassword!";
            Авторизация auth = new Авторизация();
            bool result = auth.AuthorizeUser(login, incorrectPassword);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void TestAuthorizeUserCorrect()
        {
            string login = "Admin1!";
            string password = "Admin11!";
            Авторизация auth = new Авторизация();
            bool result = auth.AuthorizeUser(login, password);
            Assert.IsTrue(result);
        }

    }
}
