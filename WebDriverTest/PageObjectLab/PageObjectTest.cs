using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectLab.PageObjects;

namespace PageObjectLab
{
    public class PageObjectTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [Test]
        public void AddingProductToBasket()
        {
            string productName = "Джинсы";
            var productsPage = new ProductsPage(driver);
            productsPage.GoToPage();
            productsPage.AddToCart(productName);
            var basketPage = productsPage.GoToBasketPage();
            var productInBasket = basketPage.CheckProduct();
            Assert.IsTrue(productName.Contains(productInBasket));
        }

        [Test]
        public void CheckBrandFilter()
        {
            var productsPage = new ProductsPage(driver);
            productsPage.GoToPage();
            var selectedBrand = productsPage.ApplyFirstBrandFilter();
            var firstBrand = productsPage.CheckFirstProductBrand();
            Assert.IsTrue(selectedBrand.Contains(firstBrand.Split("/")[0].Trim()));
        }
    }
}