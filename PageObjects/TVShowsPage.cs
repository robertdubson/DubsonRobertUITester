
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
        #region Fields

        public string InsertedText { get; private set; }

        public string CurrentURL { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".glyphicon-search")]
        private IWebElement _searchButton;

        [FindsBy(How = How.CssSelector, Using = "#search-term")]
        private IWebElement _searchText;

        private IWebDriver _webDriver;

        private WebDriverWait _wait;

        #endregion

        #region Constructors

        public TVShowsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(1000));

            CurrentURL = _webDriver.Url;

            //PageFactory.InitElements(webDriver, this);
            
            InitElements();
        }

        #endregion

        #region Methods

        public string GetCurrentURL()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.rottentomatoes.com/top-tv"));
            return _webDriver.Url;
        }


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
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".glyphicon-search")));
            _searchButton = _webDriver.FindElement(By.CssSelector(".glyphicon-search"));
        }

        public void InsertText(string text)
        {

            _searchText.SendKeys(text);

            InsertedText = _searchText.Text;
        }

        #endregion
    }
}
