using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO = MindEval.FiveSquare.Common;
using BL= MindEval.FiveSquare.Business;

namespace MindEval.FiveSquare.Test
{
    [TestClass]
    public class UserTest
    {
        private const string TOKEN = "bWFydGluQGdtYWlsLmNvbTptYXJ0aW5AMTIz";
        [TestMethod]
        public void Login()
        {
            BL.IUser user = new BL.User();
            if (new BL.AccountService().IsLogged(TOKEN))
                user.Logout(TOKEN);

            string token = user.Login("martin@gmail.com", "martin@123");
            Assert.IsFalse(string.IsNullOrEmpty(token));
        }

        [TestMethod]
        public void BadPasswordLogin()
        {
            try {
                string token = new BL.User().Login("martin@gmail.com", "martin123");
            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex is DTO.MamalonaException);
            }
        }

        [TestMethod]
        public void Register()
        {
            DTO.User user = new DTO.User();
            user.Name = "Karla";
            user.LastName = "Magallanes";
            user.Password = "123@arkus";
            user.Email = "karlaMagallanes@gmail.com";
            user.Years = 27;
            user.Sex = "Female";
            new BL.User().Register(user);            
        }

        [TestMethod]
        public void RegisterWithMissingParams()
        {
            try {
                DTO.User user = new DTO.User();
                user.Years = 27;
                user.Sex = "Female";
                new BL.User().Register(user);
            }
            catch(Exception mamalona)
            {
                Assert.IsTrue(mamalona is DTO.MamalonaException);
            }
        }      
    }
}
