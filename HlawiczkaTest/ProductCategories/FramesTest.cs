using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HlawiczkaTestCore.ProductCategoriesPage;
using HlawiczkaTestCore;

namespace HlawiczkaTest.ProductCategories
{
    [TestFixture]
    public class FramesTest : CommonFunctions
    {
        #region Fields
        public static string MAIN_PAGE = "https://www.meble.pl";
        public static ChromeDriver _driver;
        #endregion

        [SetUp]
        public void SetUp()
        {
            this.OpenPage(MAIN_PAGE);
        }

        [Test]
        public void CheckIfFrameItemAddedCorrectlyToCart()
        {
            new FramesPage(this.Driver).AddItemToCart();

            var ElementInACart = this.Driver.FindElement(By.XPath(string.Format("//td[@colspan='6']/table/tbody/tr/td/div/div/a[text()='{0}']", HlawiczkaTestCore.ProductCategoriesPage.FramesPage.productName)));
            Assert.IsTrue(ElementInACart.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            this.Close();
        }
    }
}
