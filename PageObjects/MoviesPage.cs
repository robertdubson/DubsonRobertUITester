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
        #region Fields

        public string InsertedText { get; private set; }

        public string CurrentURL { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "search-submit")]
        private IWebElement _searchButton;

        [FindsBy(How = How.CssSelector, Using = "#navbar > search-algolia > search-algolia-controls > input")]
        private IWebElement _searchText;

        private IWebDriver _webDriver;

        private WebDriverWait _wait;

        #endregion

        #region Constructors

        public MoviesPage(IWebDriver driver)
        {
            _webDriver = driver;

            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));

            CurrentURL = _webDriver.Url;

            InitElements();
        }

        #endregion

        #region Methods
        public string GetCurrentURL()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.rottentomatoes.com/browse/opening"));
            return _webDriver.Url;
        }

        public void InitElements()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#navbar > search-algolia > search-algolia-controls > input")));
            _searchText = _webDriver.FindElement(By.CssSelector("#navbar > search-algolia > search-algolia-controls > input"));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("search-submit")));
            _searchButton = _webDriver.FindElement(By.ClassName("search-submit"));
        }

        public ResultPage Search(string text)
        {
            InsertText(text);

            _searchButton.Click();

            return new ResultPage(_webDriver);
        }

        public void InsertText(string text)
        {
            _searchText = _webDriver.FindElement(By.CssSelector("#navbar > search-algolia > search-algolia-controls > input"));

            _searchText.SendKeys(text);

            InsertedText = _searchText.Text;
        }

        #endregion
    }
}
