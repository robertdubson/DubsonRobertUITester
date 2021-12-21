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
    public class HomePage : IPage
    {
        #region Fields
        public string InsertedText { get; private set; }

        public string CurrentURL { get; private set; }

        private IWebDriver _webDriver;

        private WebDriverWait _wait;

        public IWebElement SearchText { get { return _searchText; } set { _searchText = value; } }

        [FindsBy(How = How.CssSelector, Using = "#navbar > ul > li:nth-child(1) > a")]
        private IWebElement _about;

        [FindsBy(How = How.XPath, Using = "/ html / body / div[4] / header / nav / div[2] / ul / li[1] / a")]
        private IWebElement _movies;

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/header/nav/div[2]/ul/li[2]/a")]
        private IWebElement _tvShows;

        [FindsBy(How = How.CssSelector, Using = "#navbar > search-algolia > search-algolia-controls > input")]
        private IWebElement _searchText;

        [FindsBy(How = How.CssSelector, Using = "#navbar > ul > li:nth-child(2) > a")]
        private IWebElement _criticsPage;

        #endregion

        #region Constructors

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(1000));

            GoToPage();

            //PageFactory.InitElements(webDriver, this);

            InitElements();

        }

        public void GoToPage() 
        {

            _webDriver.Navigate().GoToUrl("https://www.rottentomatoes.com/");


        }

        public string GetCurrentURL()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.rottentomatoes.com/"));
            return _webDriver.Url;
        }

        public void InitElements() 
        {
            _about = _webDriver.FindElement(By.CssSelector("#navbar > ul > li:nth-child(1) > a"));
            _movies = _webDriver.FindElement(By.XPath("/html/body/div[4]/header/nav/div[2]/ul/li[1]/a"));
            _tvShows = _webDriver.FindElement(By.XPath("/html/body/div[4]/header/nav/div[2]/ul/li[2]/a"));
            _searchText = _webDriver.FindElement(By.CssSelector("#navbar > search-algolia > search-algolia-controls > input"));
            _criticsPage = _webDriver.FindElement(By.CssSelector("#navbar > ul > li:nth-child(2) > a"));
        }

        public AboutPage GoToAboutPage() 
        {
            _about.Click();

            return new AboutPage(_webDriver);
        }

        public CriticsPage GoToCriticsPage() {

            _criticsPage.Click();
            
            return new CriticsPage(_webDriver);

        }

        public MoviesPage GoToMoviesPage() 
        {
            _movies.Click();

            return new MoviesPage(_webDriver);

        }

        public TVShowsPage GoToTVShowsPage() 
        {
            _tvShows.Click();

            return new TVShowsPage(_webDriver);

            
        }

        public void InsertText(string text)
        {
            _searchText.SendKeys(text);

            InsertedText = _searchText.Text;
        }
        
        #endregion
    }
}
