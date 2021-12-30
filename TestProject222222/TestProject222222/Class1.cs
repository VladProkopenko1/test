using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject3
{
    public class Class1 : IDisposable
    {
        private IWebDriver _driver;

        public IWebDriver StartDriverWithURL(string url)
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(url);
            return _driver;
        }
        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
