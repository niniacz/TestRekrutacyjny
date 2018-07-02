using NUnit.Framework;
using HlawiczkaTestCore.AccountPage;
using HlawiczkaTestCore;

namespace HlawiczkaTest.Account
{
    [TestFixture]
    public class LogInTest : CommonFunctions
    {
        #region Xpaths
        public static string MAIN_PAGE = "https://www.meble.pl";
        private const string CurrentOrdersTextXpath = "//a[text()='Aktualne zamówienia']";
        private const string FurniureButtonXpath = "//a[text()='Wyposażenie wnętrz']";
        private const string MirrosPageXpath = "//a[text()='Ramki na zdjęcia']";
        #endregion

        #region PrivateFields
        private string login = "testrekrutacyjny@wp.pl";
        private string password = "test123";
        #endregion

        [SetUp]
        public void SetUp()
        {
            this.OpenPage(MAIN_PAGE);
        }

        [Test]
        public void LogIn()
        {
            new LogInPage(this.Driver).LogIn(login, password);

            var CurrentOrdersText = this.Driver.FindElementByXPath(CurrentOrdersTextXpath);
            Assert.IsTrue(CurrentOrdersText.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            this.Close();
        }
    }
}
