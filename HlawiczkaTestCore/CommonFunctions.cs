using OpenQA.Selenium.Chrome;

namespace HlawiczkaTestCore
{
    public class CommonFunctions
    {
        public ChromeDriver Driver { get { return _driver; } }

        #region Private fields
        private ChromeDriver _driver;
        #endregion

        #region Methods
        public void OpenPage(string webadress)
        {
            _driver = new ChromeDriver();

            _driver.Navigate().GoToUrl(webadress);
            _driver.Manage().Window.Maximize();
        }
     
        public void Close()
        {
            _driver.Close();
            _driver.Quit();
        }
        #endregion
        
    }
}
