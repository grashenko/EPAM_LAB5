using OpenQA.Selenium;
using System.Threading;

namespace WebDriverTest
{
    public static class CartPage
    {
        public static string pageUrl = "https://lk.wildberries.by/basket";
        public static string searchInputTagId = "tbSrch";
        public static string firstProductPath = "//*[@class='autocomplete-list']/li[1]/a[1]";
        public static string addToCartButtonPath = "//*[@class='cart-btn-wrap']/button[1]";
        public static string firstSizeButton = "//*[@class='j-size-list size-list j-smart-overflow-instance']/label[1]";
        public static string firstProductInCartPath = "//*[@class='basket-list-items']/div[1]/div[1]/div[1]/a[1]/span[2]";

        public static void AddToCart(string productName, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(MainPage.pageUrl);
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

        public static string CheckAddingToCart(string productName, IWebDriver driver)
        {
            AddToCart(productName, driver);
            driver.Navigate().GoToUrl(pageUrl);
            string productTitle = driver.FindElement(By.XPath(firstProductInCartPath)).Text;
            return productTitle;
        }

        public static void SlowType(IWebElement webElement, string text)
        {
            webElement.Click();
            webElement.Clear();
            foreach (var key in text)
            {
                webElement.SendKeys(key.ToString());
                Thread.Sleep(150);
            }
        }
    }
}
