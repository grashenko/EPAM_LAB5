﻿using OpenQA.Selenium;
using System.Threading;

namespace WebDriverTest
{
    public static class MainPage
    {
        public static string pageUrl = "https://www.wildberries.by/";
        public static string searchInputTagId = "tbSrch";
        public static string firstProductPath = "//*[@class='autocomplete-list']/li[1]/a[1]/div[1]/span[1]";

        public static string GetSearchFieldValue(string productName, IWebDriver driver)
        {
            driver.Navigate().GoToUrl(pageUrl);
            IWebElement searchElement = driver.FindElement(By.Id(searchInputTagId));
            CartPage.SlowType(searchElement, productName);
            Thread.Sleep(3000);

            string prductTitle = driver.FindElement(By.XPath(firstProductPath)).Text;
            return prductTitle;
        }
    }
}
