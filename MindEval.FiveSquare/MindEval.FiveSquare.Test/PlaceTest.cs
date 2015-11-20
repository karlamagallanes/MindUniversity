using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BL = MindEval.FiveSquare.Business;
using DTO = MindEval.FiveSquare.Common;

namespace MindEval.FiveSquare.Test
{
    [TestClass]
    public class PlaceTest
    {
        private const string TOKEN = "bWFydGluQGdtYWlsLmNvbTptYXJ0aW5AMTIz";
        private const string EMAIL = "martin@gmail.com";
        private const string PASSWORD = "martin@123";
        private const int CONORADO_BREWING_COMPANY_ID = 7;
        private const int CECUT_ID = 4;

        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void GetNearbyPlaces()
        {
            string token = (new BL.AccountService().IsLogged(TOKEN) ? TOKEN : new BL.User().Login(EMAIL, PASSWORD));
            List<DTO.Place> places = new BL.Place().GetNearby((decimal)32.522214, (decimal)-117.019112, token);
            Assert.IsNotNull(places);
            Assert.IsTrue(places.Count == 5);
        }
    }
}