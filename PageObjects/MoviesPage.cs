using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class MoviesPage : IPage
    {
        public string InsertedText { get; private set; }

        private IWebDriver _webDriver;

        private WebDriverWait _wait;

        public MoviesPage(IWebDriver driver)
        {
            _webDriver = driver;

            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#navbar > search-algolia > search-algolia-controls > input")]
        private IWebElement _searchText;

        public ResultPage Search(string text)
        {
            _searchText.SendKeys(text);

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("span > svg"))).Click();

            return new ResultPage(_webDriver);
        }

        public void InsertText(string text)
        {
            _searchText.SendKeys(text);

            InsertedText = _searchText.Text;
        }

    }
}
