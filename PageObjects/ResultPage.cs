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
        public string InsertedText { get; private set; }

        private IWebDriver _webDriver;

        private WebDriverWait _wait;

        public ResultPage(IWebDriver driver)
        {
            _webDriver = driver;

            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#navbar > search-algolia > search-algolia-controls > input")]
        private IWebElement _searchText;

        [FindsBy(How = How.CssSelector, Using = "#main-page-content > div > section.search__main.layout__column.layout__column--main > search-page-result-container > search-page-result:nth-child(2) > ul > search-page-media-row:nth-child(1) > a:nth-child(2)")]
        
        private IWebElement _firstMovie;

        public IWebElement MovieTitle { get; private set; }

        public void ClickOnFirstMovie()
        {
            _firstMovie.Click();
            MovieTitle = _webDriver.FindElement(By.CssSelector("#topSection > div.thumbnail-scoreboard-wrap > score-board > h1"));
        }

        public void InsertText(string text)
        {
            _searchText.SendKeys(text);

            InsertedText = _searchText.Text;
        }

    }
}
