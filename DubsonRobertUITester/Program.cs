using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubsonRobertUITester
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://ecampus.kpi.ua/home");

            IWebElement element = driver.FindElement(By.ClassName("form-control"));

            element.SendKeys("my login");

            String writtenLogin = element.Text;

            Assert.IsTrue(writtenLogin=="my login");
        }
    }
}
