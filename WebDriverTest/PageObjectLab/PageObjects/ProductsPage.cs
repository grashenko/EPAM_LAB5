using OpenQA.Selenium;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace PageObjectLab.PageObjects
{
    public class ProductsPage
    {
        private IWebDriver driver;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private string filterBrandCheckBox = "//*[@id='brand_list_left']/li[1]";
        private string firstProductBrand = "//*[@class='dtlist-inner-brand-name']/strong[1]";
        private string brandButton = "div[class='filterblock brand show']";

        public string searchInputTagId = "tbSrch";
        public string firstProductPath = "//*[@class='autocomplete-list']/li[1]/a[1]";
        public string addToCartButtonPath = "//*[@class='cart-btn-wrap']/button[1]";
        public string firstSizeButton = "//*[@class='j-size-list size-list j-smart-overflow-instance']/label[1]";
        public string firstProductInCartPath = "//*[@class='basket-list-items']/div[1]/div[1]/div[1]/a[1]/span[2]";

        public void AddToCart(string productName)
        {
            IWebElement searchElement = driver.FindElement(By.Id(searchInputTagId));
            SlowType(searchElement, productName);
            Thread.Sleep(3000);

            driver.FindElement(By.XPath(firstProductPath)).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath(firstSizeButton)).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath(addToCartButtonPath)).Click();
            Thread.Sleep(3000);
        }

        public void SlowType(IWebElement webElement, string text)
        {
            webElement.Click();
            webElement.Clear();
            foreach (var key in text)
            {
                webElement.SendKeys(key.ToString());
                Thread.Sleep(150);
            }
        }

        public string ApplyFirstBrandFilter()
        {
            Thread.Sleep(3000);
            var filterButton = driver.FindElement(By.CssSelector(this.brandButton));
            filterButton.Click();
            Thread.Sleep(3000);
            var brand = driver.FindElement(By.XPath(this.filterBrandCheckBox));
            brand.Click();
            return brand.Text;
        }

        public string CheckFirstProductBrand()
        {
            Thread.Sleep(2000);
            var firstProduct = driver.FindElement(By.XPath(this.firstProductBrand));
            return firstProduct.Text;
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://www.wildberries.by/catalog/muzhchinam/odezhda/bryuki-i-shorty");
        }

        public BasketPage GoToBasketPage()
        {
            return new BasketPage(driver);
        }
    }
}
