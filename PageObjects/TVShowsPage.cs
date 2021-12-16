
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

        private IWebDriver _webDriver;

        private WebDriverWait _wait;

        public TVShowsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#navbar > search-algolia > search-algolia-controls > input")]
        private IWebElement _searchText;

        public ResultPage Search(string text)
        {
            InsertText(text);

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
