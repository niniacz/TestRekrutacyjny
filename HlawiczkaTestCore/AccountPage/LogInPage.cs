using OpenQA.Selenium.Remote;

namespace HlawiczkaTestCore.AccountPage
{
   public class LogInPage: CommonFunctions
    {
        private RemoteWebDriver _driver;

        public LogInPage(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        #region Xpaths
        private const string AccountButtonXpath = "//a[text()='zaloguj']";
        private const string LogInButtonXpath = "//input[@value='ZALOGUJ SIĘ']";
        private const string LogInInputXpath = " //input[@id='login']";
        private const string PasswordInputXpath = "//input[@id='haslo']";
        private const string CurrentOrdersTextXpath = "//a[text()='Aktualne zamówienia']";
        #endregion
        
        public void LogIn(string login, string password)
        {
            new DashboardPage(_driver).GoToLogInPage();
            
            var LogInButton = _driver.FindElementByXPath(LogInButtonXpath);
            var LogInInput = _driver.FindElementByXPath(LogInInputXpath);
            var PasswordInput = _driver.FindElementByXPath(PasswordInputXpath);
            LogInInput.SendKeys(login);
            PasswordInput.SendKeys(password);
            LogInButton.Click();
        }
        
    }
}
