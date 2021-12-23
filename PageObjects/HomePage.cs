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

        [FindsBy(How = How.CssSelector, Using = "a[href='/about']")]
        private IWebElement _about;

        [FindsBy(How = How.CssSelector, Using = ".masthead__menu-header--active .masthead__menu-header-title")]
        private IWebElement _movies;

        [FindsBy(How = How.CssSelector, Using = ".masthead__menu-header-title[href='https://www.rottentomatoes.com/top-tv']")]
        private IWebElement _tvShows;

        [FindsBy(How = How.CssSelector, Using = ".search-text")]
        private IWebElement _searchText;

        [FindsBy(How = How.CssSelector, Using = ".masthead__header-link[href='/critics']")]
        private IWebElement _criticsPage;

        #endregion

        #region Constructors

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(1000));

            GoToPage();

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
            _about = _webDriver.FindElement(By.CssSelector("a[href='/about']"));
            _movies = _webDriver.FindElement(By.CssSelector(".masthead__menu-header-title[href='/browse/opening/']"));
            _tvShows = _webDriver.FindElement(By.CssSelector(".masthead__menu-header-title[href='https://www.rottentomatoes.com/top-tv']"));
            _searchText = _webDriver.FindElement(By.CssSelector(".search-text"));
            _criticsPage = _webDriver.FindElement(By.CssSelector(".masthead__header-link[href='/critics']"));
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
