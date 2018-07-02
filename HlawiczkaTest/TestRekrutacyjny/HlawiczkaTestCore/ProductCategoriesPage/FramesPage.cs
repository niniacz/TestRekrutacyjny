using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace HlawiczkaTestCore.ProductCategoriesPage
{
public    class FramesPage:CommonFunctions
    {
        private RemoteWebDriver _driver;
        public static string productName;
        
        public FramesPage(RemoteWebDriver driver)
        {
            _driver = driver;
        }
        #region Xpaths
        private  const string KeepBuyingButtonXpath = "//input[@value='Kupuję dalej']";
        private const string AddToCartButtonXpath = "//a[@class='button add-to-cart']";
        #endregion
        public void AddItemToCart()
        {
            new DashboardPage(_driver).GoToFramesPage();

            IList<IWebElement> FramesElementsList = _driver.FindElements(By.XPath("//div[@class='katalog_produktow meble wyposazenie-wnetrz wyposazenie-salonu- product-list-big']/div"));
            int numberOfItemsOnThelist = FramesElementsList.Count;
            Random r = new Random();
            int r1 = r.Next(0, numberOfItemsOnThelist);
            int r2 = r.Next(0, numberOfItemsOnThelist);

            var FrameItem = _driver.FindElement(By.XPath(string.Format("//div[@class='katalog_produktow meble wyposazenie-wnetrz wyposazenie-salonu- product-list-big']/div[{0}]", r1)));
            var prodName = _driver.FindElement(By.XPath(string.Format("//div[@class='katalog_produktow meble wyposazenie-wnetrz wyposazenie-salonu- product-list-big']/div[{0}]/div/div/div[3]/div[2]/a", r1)));
            productName = prodName.GetAttribute("text");
      
            Actions action2 = new Actions(_driver);
            action2.MoveToElement(FrameItem).Perform();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElementByXPath(string.Format("//div[{0}]/div/div/div/a/span/img[1]", r1)))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElementByXPath(AddToCartButtonXpath))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElementByXPath(KeepBuyingButtonXpath))).Click();

            string basket = "https://www.meble.pl/koszyk/";
            _driver.Navigate().GoToUrl(basket);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }

    }
}
