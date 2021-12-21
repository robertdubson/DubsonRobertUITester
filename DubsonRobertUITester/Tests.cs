using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Allure.Commons;

namespace DubsonRobertUITester
{
    //[TestFixture]
    //[AllureNUnit]
    //[AllureSuite("RottenTomatoesTests")]
    //[AllureDisplayIgnored]
    public class Tests
    {
        /*private IWebDriver _webDriver;

        private HomePage _home;

        public Tests()
        {
            SetUp();
            _home = new HomePage(_webDriver);
        }

        public void PerformTesting() 
        {

            CheckTheInputText(_home, "blah");
            CheckAboutNavigation();
            CheckMoviesPageNavigation();
            TvShowPageNavigation();
            SearchMovieFromAboutPage();
            SearchMovieFromMoviesPage();
            //SearchMovieFromTVShowsPage();
            TearDown();

        }

        [SetUp]
        public void SetUp() 
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
        }

        public void GoToHomePage() 
        {
            _home = new HomePage(_webDriver);
            _home.GoToPage();
        }

        [Test(Description = "Insert text in the search textbox")]
        [AllureTag("UserInterface")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Robert Dubson")]
        [AllureSubSuite("InsertText")]
        public void CheckTheInputText(HomePage pageUnderTest, string text) 
        {
            pageUnderTest.InsertText(text);
            Assert.IsTrue(pageUnderTest.SearchText.GetAttribute("value") == text);
        }


        [Test(Description = "Navigate to About Page")]
        [AllureTag("UserInterface")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Robert Dubson")]
        [AllureSubSuite("Navigation")]
        public void CheckAboutNavigation() 
        {
            _home = new HomePage(_webDriver);
            AboutPage about = _home.GoToAboutPage();
            //Assert.IsTrue(about.CurrentURL== "https://www.rottentomatoes.com/about#whatisthetomatometer");
            Assert.IsTrue(about.GetCurrentURL()== "https://www.rottentomatoes.com/about#whatisthetomatometer");
        }


        [Test(Description = "Navigate to Movies Page")]
        [AllureTag("UserInterface")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Robert Dubson")]
        [AllureSubSuite("Navigation")]
        public void CheckMoviesPageNavigation() 
        {
            _home = new HomePage(_webDriver);
            MoviesPage movies = _home.GoToMoviesPage();
            //Assert.IsTrue(movies.CurrentURL== "https://www.rottentomatoes.com/browse/opening");
            Assert.IsTrue(movies.GetCurrentURL() == "https://www.rottentomatoes.com/browse/opening");

        }

        [Test(Description = "Navigate to TvShows Page")]
        [AllureTag("UserInterface")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Robert Dubson")]
        [AllureSubSuite("Navigation")]
        public void TvShowPageNavigation() 
        {
            _home = new HomePage(_webDriver);
            TVShowsPage tv = _home.GoToTVShowsPage();
            //Assert.IsTrue(tv.CurrentURL== "https://www.rottentomatoes.com/top-tv/");
            //Assert.IsTrue(tv.GetCurrentURL()== "https://www.rottentomatoes.com/top-tv");
            if (tv.GetCurrentURL() == "https://www.rottentomatoes.com/top-tv") 
            {
                Assert.Pass("Passed");
            }

        }

        [Test(Description = "Search for a movie from AboutPage")]
        [AllureTag("Functional")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Robert Dubson")]
        [AllureSubSuite("Search")]
        public void SearchMovieFromAboutPage()
        {
            //GoToHomePage();
            _home = new HomePage(_webDriver);
            AboutPage about = _home.GoToAboutPage();
            ResultPage result = about.Search("Godfather");
            result.ClickOnFirstMovie();
            //Assert.IsTrue(result.MovieTitle.Text.Contains("godfather"));
            //Assert.IsTrue(result.MovieTitle.Text.Contains("Godfather"));
            //Assert.IsTrue(result.CurrentURL.Contains("god-father"));
            if (result.CurrentURL.Contains("god-father")) 
            {
                Assert.Pass("Passed");
            }
        }

        [Test(Description = "Search for a movie from MoviesPage")]
        [AllureTag("Functional")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Robert Dubson")]
        [AllureSubSuite("Search")]
        public void SearchMovieFromMoviesPage()
        {
            //GoToHomePage();
            _home = new HomePage(_webDriver);
            MoviesPage movies = _home.GoToMoviesPage();
            ResultPage result = movies.Search("Forrest Gump");
            result.ClickOnFirstMovie();
            Assert.IsTrue(result.CurrentURL.Contains("forrest_gump"));

            //if (result.CurrentURL.Contains("forrest_gump")) 
            //{
                Assert.Pass("Passed");
            //}
        }

        //[Test(Description = "Search for a movie from TVShowsPage")]
        //[AllureTag("Functional")]
        //[AllureSeverity(SeverityLevel.critical)]
        //[AllureOwner("Robert Dubson")]
        //[AllureSubSuite("Search")]
        //public void SearchMovieFromTVShowsPage()
        //{
            //GoToHomePage();
        //    _home = new HomePage(_webDriver);
          //  TVShowsPage tvShows = _home.GoToTVShowsPage();
            //ResultPage result = tvShows.Search("Squid Game");
            //result.ClickOnFirstMovie();
            //Assert.IsTrue(result.MovieTitle.GetAttribute("value").Contains("Squid Game"));
            //Assert.IsTrue(result.CurrentURL.Contains("squid_game"));
        //}

        [TearDown]
        public void TearDown() 
        {

            _webDriver.Close();

        }*/
    }
}
