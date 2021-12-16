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
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("RottenTomatoesTests")]
    [AllureDisplayIgnored]
    public class Tests
    {
        private IWebDriver _webDriver;

        private HomePage _home;

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
        public void CheckTheInputText(IPage pageUnderTest, string text) 
        {
            pageUnderTest.InsertText(text);
            Assert.AreEqual(pageUnderTest.InsertedText, text);
        }

        [Test(Description = "Search for a movie from AboutPage")]
        [AllureTag("Functional")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Robert Dubson")]
        [AllureSubSuite("Search")]
        public void SearchMovieFromAboutPage()
        {
            GoToHomePage();
            AboutPage about = _home.GoToAboutPage();
            ResultPage result = about.Search("godfather");
            result.ClickOnFirstMovie();
            Assert.IsTrue(result.MovieTitle.Text.Contains("godfather"));
        }

        [Test(Description = "Search for a movie from MoviesPage")]
        [AllureTag("Functional")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Robert Dubson")]
        [AllureSubSuite("Search")]
        public void SearchMovieFromMoviesPage()
        {
            GoToHomePage();
            MoviesPage movies = _home.GoToMoviesPage();
            ResultPage result = movies.Search("Forrest Gump");
            result.ClickOnFirstMovie();
            Assert.IsTrue(result.MovieTitle.Text.Contains("Forrest Gump"));
        }

        [Test(Description = "Search for a movie from TVShowsPage")]
        [AllureTag("Functional")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Robert Dubson")]
        [AllureSubSuite("Search")]
        public void SearchMovieFromTVShowsPage()
        {
            GoToHomePage();
            TVShowsPage tvShows = _home.GoToTVShowsPage();
            ResultPage result = tvShows.Search("Squid Game");
            result.ClickOnFirstMovie();
            Assert.IsTrue(result.MovieTitle.Text.Contains("Squid Game"));
        }

        [TearDown]
        public void TearDown() 
        {

            _webDriver.Close();

        }
    }
}
