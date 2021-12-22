using NUnit.Framework;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Allure.Commons;
namespace UnitTests
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
            Assert.IsTrue(about.GetCurrentURL() == "https://www.rottentomatoes.com/about#whatisthetomatometer");
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
            Assert.IsTrue(tv.GetCurrentURL()== "https://www.rottentomatoes.com/top-tv");  

        }


        [Test(Description = "Navigate to Critics Page")]
        [AllureTag("UserInterface")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Robert Dubson")]
        [AllureSubSuite("Navigation")]
        public void CriticsPageNavigation() {

            _home = new HomePage(_webDriver);
            CriticsPage result = _home.GoToCriticsPage();
            Assert.IsTrue(result.GetCurrentURL()=="https://www.rottentomatoes.com/critics");

        }


        [Test(Description = "Redirect To Critic's biorgaphy")]
        [AllureTag("UserInterface")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Robert Dubson")]
        [AllureSubSuite("TitleCheck")]
        public void CheckCriticsName() {

            _home = new HomePage(_webDriver);
            CriticsPage criticsPage = _home.GoToCriticsPage();
            ResultPage res = criticsPage.ClickOnFirstCritic();
            Assert.IsTrue(res.ClickedCritic==res.GetCriticName());

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
            result.FindTheTitle(); 
            Assert.IsTrue(result.FirstMovieTitle.Contains("Godfather"));
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
            result.FindTheTitle();
            Assert.IsTrue(result.FirstMovieTitle.Contains("Forrest Gump"));

        }

        [TearDown]
        public void TearDown()
        {

            _webDriver.Close();

        }
    }
}