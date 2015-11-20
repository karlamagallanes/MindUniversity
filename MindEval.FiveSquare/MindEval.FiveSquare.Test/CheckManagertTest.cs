using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL = MindEval.FiveSquare.Business;

namespace MindEval.FiveSquare.Test
{
    [TestClass]
    public class CheckManagerTest
    {
        private const string TOKEN = "bWFydGluQGdtYWlsLmNvbTptYXJ0aW5AMTIz";
        private const string EMAIL = "martin@gmail.com";
        private const string PASSWORD = "martin@123";
        private const int CORONADO_BREWING_COMPANY_ID = 7;
        private const int CECUT_ID = 4;

        
        [TestMethod]
        public void CheckIn()
        {
             BL.CheckManager checkManager = new BL.CheckManager();

            string token =(new BL.AccountService().IsLogged(TOKEN) ? TOKEN : new BL.User().Login(EMAIL, PASSWORD));

            checkManager.CheckIn(CORONADO_BREWING_COMPANY_ID, token);
            checkManager.CheckIn(CECUT_ID, token);
            checkManager.CheckIn(CORONADO_BREWING_COMPANY_ID, token);

            int coronadoCheckIns = checkManager.Count(CORONADO_BREWING_COMPANY_ID, token);
            int cecutCheckIns = checkManager.Count(CECUT_ID, token);

            Assert.IsTrue(coronadoCheckIns == 2);
            Assert.IsTrue(cecutCheckIns == 1);
        }

        [TestMethod]
        public void Rate()
        {
            BL.CheckManager checkManager = new BL.CheckManager();

            string token = (new BL.AccountService().IsLogged(TOKEN) ? TOKEN : new BL.User().Login(EMAIL, PASSWORD));

            checkManager.Rate(CORONADO_BREWING_COMPANY_ID, 3, token);
            checkManager.Rate(CORONADO_BREWING_COMPANY_ID, 3, token);
            checkManager.Rate(CORONADO_BREWING_COMPANY_ID, 6, token);

            decimal rate = checkManager.Rate(CORONADO_BREWING_COMPANY_ID, token);

            Assert.IsTrue(rate == 4);
        }


    }
}