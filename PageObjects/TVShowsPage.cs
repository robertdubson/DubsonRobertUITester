
using OpenQA.Selenium;
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
    
    public class TVShowsPage : IPage
    {
        public string InsertedText { get; private set; }

        public string CurrentURL { get; private set; }

        [FindsBy(How = How.CssSelector, Using = "#search-form > div > div > div.input-group > div.input-group-btn > button > em")]
        private IWebElement _searchButton;

        [FindsBy(How = How.CssSelector, Using = "#main-page-content > div > section.search__main.layout__column.layout__column--main > search-page-result-container > nav > ul > li.js-search-filter.searchNav__filter.searchNav__filter--active > span")]
        private IWebElement _tvShowsButton;

        private IWebDriver _webDriver;

        private WebDriverWait _wait;

        public string GetCurrentURL()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.rottentomatoes.com/top-tv"));
            return _webDriver.Url;
        }

        public TVShowsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(1000));

            CurrentURL = _webDriver.Url;

            //PageFactory.InitElements(webDriver, this);
            
            InitElements();
        }

        [FindsBy(How = How.CssSelector, Using = "#search-term")]
        private IWebElement _searchText;

        public ResultPage Search(string text)
        {
            InsertText(text);

            _searchButton.Click();

            return new ResultPage(_webDriver);
        }

        public void InitElements()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#search-term")));
            _searchText = _webDriver.FindElement(By.CssSelector("#search-term"));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#search-form > div > div > div.input-group > div.input-group-btn > button > em")));
            _searchButton = _webDriver.FindElement(By.CssSelector("#search-form > div > div > div.input-group > div.input-group-btn > button > em"));
        }

        public void InsertText(string text)
        {
            //_searchText = _webDriver.FindElement(By.CssSelector("#navbar > search-algolia > search-algolia-controls > input"));

            _searchText.SendKeys(text);

            InsertedText = _searchText.Text;
        }
    }
}
