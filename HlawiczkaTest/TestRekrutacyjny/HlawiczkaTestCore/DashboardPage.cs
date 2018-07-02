using System;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace HlawiczkaTestCore
{
   public class DashboardPage : CommonFunctions
    {
        private RemoteWebDriver _driver;

        public DashboardPage(RemoteWebDriver driver)
        {
            _driver = driver;
        }
        #region Xpaths
        private const string AccountButtonXpath = "//a[text()='zaloguj']";
        private const string FurniureButtonXpath = "//a[text()='Wyposażenie wnętrz']";
        private const string MirrosPageXpath = "//a[text()='Ramki na zdjęcia']";
        #endregion
        public void GoToLogInPage()
        {
            var AccountButton = _driver.FindElementByXPath(AccountButtonXpath);
            AccountButton.Click();
        }
        public void GoToFramesPage()
        {
            var FurnitureButton = _driver.FindElementByXPath(FurniureButtonXpath);
            Actions action = new Actions(_driver);
            action.MoveToElement(FurnitureButton).Perform();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElementByXPath(MirrosPageXpath))).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }
    }
}
