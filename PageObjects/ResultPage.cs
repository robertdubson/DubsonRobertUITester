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
    public class ResultPage : IPage
    {

        #region Fields
        public string InsertedText { get; private set; }

        public string FirstMovieTitle { get; private set; }

        public string ClickedCritic { get; set; } 

        private IWebDriver _webDriver;

        private WebDriverWait _wait;

        public string CurrentURL { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".search-text")]
        private IWebElement _searchText;

        [FindsBy(How = How.CssSelector, Using = "search-page-media-row , .unset")]
        private IWebElement _firstMovie;

        [FindsBy(How = How.ClassName, Using = "scoreboard__title")]
        public IWebElement MovieTitle { get; private set; }

        #endregion

        #region Constructors

        public ResultPage(IWebDriver driver)
        {
            _webDriver = driver;

            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));

            CurrentURL = _webDriver.Url;

            InitElements();
        }

        public ResultPage(IWebDriver driver, string critic)
        {
            _webDriver = driver;

            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));

            CurrentURL = _webDriver.Url;

            ClickedCritic = critic;

        }

        #endregion

        #region Methods

        public string GetCurrentURL()
        {
            return _webDriver.Url;
        }

        public void InitElements()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".search-text")));
            _searchText = _webDriver.FindElement(By.CssSelector(".search-text"));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("search-page-media-row , .unset")));
            _firstMovie = _webDriver.FindElement(By.CssSelector("search-page-media-row , .unset"));
        }

        

        public void FindTheTitle() {

            FirstMovieTitle = _firstMovie.GetAttribute("text");

        }

        public void ClickOnFirstMovie()
        {
            
            _firstMovie.Click();
            CurrentURL = _webDriver.Url;

        }

        public void InsertText(string text)
        {
            _searchText = _webDriver.FindElement(By.CssSelector(".search-text"));

            _searchText.SendKeys(text);

            InsertedText = _searchText.Text;
        }

        public string GetCriticName() {

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".critic-person__bio__summary div , h1")));

            return _webDriver.FindElement(By.CssSelector(".critic-person__bio__summary div , h1")).GetAttribute("text").ToString();

        }

        #endregion

    }
}
