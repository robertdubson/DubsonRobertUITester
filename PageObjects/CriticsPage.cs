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
    public class CriticsPage : IPage
    {

        #region Fields

        private IWebDriver _webDriver;

        private WebDriverWait _wait;

        [FindsBy(How = How.CssSelector, Using = "#critics-home-spotlight > div > ul > li:nth-child(1) > div > a")]
        private IWebElement _criticName;

        [FindsBy(How = How.CssSelector, Using = "#navbar > search-algolia > search-algolia-controls > input")]
        private IWebElement _searchTextBox;

        public string InsertedText { get; private set; }

        public string CurrentURL { get; private set; }

        #endregion

        #region Constructors

        public CriticsPage(IWebDriver driver)
        {

            _webDriver = driver;

            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));

            CurrentURL = _webDriver.Url;

            InitElements();

        }

        #endregion

        #region Methods

        public void InitElements() {

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#critics-home-spotlight > div > ul > li:nth-child(1) > div > a")));
            _criticName = _webDriver.FindElement(By.CssSelector("#critics-home-spotlight > div > ul > li:nth-child(1) > div > a"));

        }

        public ResultPage ClickOnFirstCritic() {

            _criticName.Click();

            return new ResultPage(_webDriver, _criticName.GetAttribute("text"));

        }

        public void InsertText(string text)
        {
            _searchTextBox.SendKeys(text);

        }

        public string GetCurrentURL()
        {
            return _webDriver.Url;
        }

        #endregion
    }
}
