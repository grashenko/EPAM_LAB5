using OpenQA.Selenium;

namespace PageObjectLab.PageObjects
{
    public class BasketPage
    {
        private IWebDriver driver;

        public static string firstProductInCartPath = "//*[@class='basket-list-items']/div[1]/div[1]/div[1]/a[1]/span[2]";

        public BasketPage(IWebDriver driver)
        {
            this.driver = driver;
            this.GoToPage();
        }

        public string CheckProduct()
        {
            string productTitle = driver.FindElement(By.XPath(firstProductInCartPath)).Text;
            return productTitle;
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://lk.wildberries.by/basket");
        }
    }
}
