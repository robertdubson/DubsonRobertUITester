using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
namespace PageObjects
{
    public class HomePage : IPage
    {
        public string InsertedText { get; private set; }

        private IWebDriver _webDriver;

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#navbar > ul > li:nth-child(1) > a")]
        private IWebElement _about;

        [FindsBy(How = How.CssSelector, Using = "#masthead-dropdown-menus > ul > li:nth-child(1) > a")]
        private IWebElement _movies;

        [FindsBy(How = How.CssSelector, Using = "#masthead-dropdown-menus > ul > li:nth-child(2) > a")]
        private IWebElement _tvShows;
        
        [FindsBy(How = How.CssSelector, Using = "#navbar > search-algolia > search-algolia-controls > input")]
        private IWebElement _searchText;
        public void GoToPage() 
        {

            _webDriver.Navigate().GoToUrl("https://www.rottentomatoes.com/");
            
        }

        public AboutPage GoToAboutPage() 
        {
            _about.Click();

            return new AboutPage(_webDriver);
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

    }
}
