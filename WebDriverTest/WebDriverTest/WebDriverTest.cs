using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverTest
{
    class WebDriverTest
    {
        private IWebDriver _driver;
        private string _productName;
        private string _firstSerchedProduct = "/ Джинсы - MOM80";

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _productName = "Джинсы";
        }

        [Test]
        public void CheckSearchField()
        {
            string searchFieldValue = MainPage.GetSearchFieldValue(_productName, _driver);
            bool expected = searchFieldValue == _firstSerchedProduct;
            Assert.IsTrue(expected);
        }

        [Test]
        public void CheckAddingToCart()
        {
            string productTitle = CartPage.CheckAddingToCart(_productName, _driver);
            bool expected = productTitle == _productName;
            Assert.IsTrue(expected);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
