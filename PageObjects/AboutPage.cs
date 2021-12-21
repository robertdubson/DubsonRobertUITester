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
    public class AboutPage : IPage
    {
        #region Fields
        private IWebDriver _webDriver;

        public string CurrentURL { get; private set; }


        [FindsBy(How = How.CssSelector, Using = "search-submit")]
        private IWebElement _searchButton;

        [FindsBy(How = How.CssSelector, Using = "#navbar > search-algolia > search-algolia-controls > input")]
        private IWebElement _searchText;


        private WebDriverWait _wait;

        public string InsertedText { get; private set; }

        #endregion

        #region Methods
        public AboutPage(IWebDriver driver)
        {
            _webDriver = driver;

            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));

            CurrentURL = _webDriver.Url;

            InitElements();

        }     

        public void InitElements()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#navbar > search-algolia > search-algolia-controls > input")));
            _searchText = _webDriver.FindElement(By.CssSelector("#navbar > search-algolia > search-algolia-controls > input"));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("search-submit")));
            _searchButton = _webDriver.FindElement(By.ClassName("search-submit"));
        }

        public string GetCurrentURL() 
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.rottentomatoes.com/about#whatisthetomatometer"));
            return _webDriver.Url;
        }

        public ResultPage Search(string text)
        {
            InsertText(text);

            _searchButton.Click();
            
            return new ResultPage(_webDriver);
        }

        public void InsertText(string text) 
        {
            
            _searchText.SendKeys(text);

            InsertedText = _searchText.Text;

        }
        #endregion

    }
}
