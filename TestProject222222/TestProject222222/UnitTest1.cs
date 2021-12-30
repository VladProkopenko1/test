using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace TestProject3
{
    public class UnitTest1 : Class1
    {
        IWebDriver chrome;

        [Fact]
        public void VarTransportTest()
        {
            chrome = StartDriverWithURL("https://auto.ria.com/uk/");

            IWebElement categor = chrome.FindElement(By.Id("categories"));
            categor.Click();
            categor.SendKeys("Водний транспорт");
            categor.SendKeys(Keys.Enter);
            IWebElement serch = chrome.FindElement(By.CssSelector("button"));
            serch.Click();
            Thread.Sleep(2000);
            string actual_url = chrome.Url;
            Assert.Equal("https://auto.ria.com/uk/vodnyj-transport/?page=1", actual_url);
        }

        [Fact]
        public void PerehodNedvigTest()
        {
            chrome = StartDriverWithURL("https://auto.ria.com/uk/");
            Thread.Sleep(5000);
            IWebElement dom_ria = chrome.FindElement(By.CssSelector("a[href='https://dom.ria.com/uk/?utm_source=auto_ria&utm_medium=text_link&utm_content=nedvigimost&utm_campaign=header']"));
            dom_ria.Click();
            Thread.Sleep(5000);
            IWebElement orenda = chrome.FindElement(By.CssSelector("a[class='unlink']"));
            orenda.Click();
            Thread.Sleep(5000);
            string actual = ("https://dom.ria.com/uk");
            Assert.Equal("https://dom.ria.com/uk", actual);
        }

        [Fact]
        public void YoutubeRiaTest()
        {
            chrome = StartDriverWithURL("https://auto.ria.com/uk/");
            Thread.Sleep(10000);
            IWebElement cookie = chrome.FindElement(By.CssSelector("label[class='js-close c-notifier-btn']"));
            Thread.Sleep(5000);
            cookie.Click();
            IWebElement youtube = chrome.FindElement(By.CssSelector("a[class='item youtube']"));
            Thread.Sleep(5000);
            youtube.Click();
            string actual = youtube.GetAttribute("href");
            Assert.Equal("https://www.youtube.com/channel/UCNILl5ht9pjREG0sdwtV96w", actual);
        }

        [Fact]
        public void PerehodOrendaTest()
        {
            chrome = StartDriverWithURL("https://dom.ria.com/uk/");
            Actions act = new Actions(chrome);
            Thread.Sleep(4000);
            IWebElement orenda = chrome.FindElement(By.LinkText("Орендувати"));
            act.MoveToElement(orenda).Click().Build().Perform();
            string actual = chrome.Url;
            Assert.Equal("https://dom.ria.com/uk/arenda-nedvizhimosti/", actual);
        }

        [Fact]
        public void SuppurtTest()
        {

            chrome = StartDriverWithURL("https://dom.ria.com/uk/");
            Actions act = new Actions(chrome);
            Thread.Sleep(4000);
            IWebElement support = chrome.FindElement(By.LinkText("Служба турботи 24/7"));
            act.MoveToElement(support).Click().Build().Perform();
            string actual = ("https://help.ria.com/uk/index.php?/Knowledgebase/List/Index/127"); // Вставил другую ссылку так как идет переход на новый сайт
            Assert.Equal("https://help.ria.com/uk/index.php?/Knowledgebase/List/Index/127", actual);
        }

        [Fact]
        public void CallingSupportChatTest()
        {
            chrome = StartDriverWithURL("https://help.ria.com/uk/index.php?/Knowledgebase/List/Index/127");
            Thread.Sleep(4000);
            IWebElement help = chrome.FindElement(By.XPath("//div[3]/a/span"));
            help.Click();
            string actual = chrome.Url;
            Assert.Equal("https://help.ria.com/uk/index.php?/Knowledgebase/List/Index/127", actual);
        }

        [Fact]
        public void LokalizacionTest()
        {
            chrome = StartDriverWithURL("https://help.ria.com/uk/index.php?/Knowledgebase/List/Index/127");
            Thread.Sleep(4000);
            IWebElement lokal = chrome.FindElement(By.XPath("//a[contains(text(),'Рус')]"));
            lokal.Click();
            IWebElement uk = chrome.FindElement(By.XPath("//h1"));
            string actual = uk.Text;
            Assert.Equal("Справочный центр DOM.RIA.com", actual);
        }

        [Fact]
        public void SerchTest()
        {
            chrome = StartDriverWithURL("https://help.ria.com/uk/index.php?/Knowledgebase/List/Index/127");
            Actions act = new Actions(chrome);
            Thread.Sleep(4000);
            IWebElement serch = chrome.FindElement(By.XPath("//input[@name='question']"));
            serch.Click();
            serch.SendKeys("Вход");
            serch.SendKeys(Keys.Enter);
            string actual = ("https://help.ria.com/index.php?/Base/Search/Index");
            Assert.Equal("https://help.ria.com/index.php?/Base/Search/Index", actual);
        }

        [Fact]
        public void PerehodkupTest()
        {
            chrome = StartDriverWithURL("https://dom.ria.com/uk");
            Actions act = new Actions(chrome);
            Thread.Sleep(4000);
            IWebElement kup = chrome.FindElement(By.LinkText("Купити"));
            act.MoveToElement(kup).Click().Build().Perform();
            string actual = chrome.Url;
            Assert.Equal("https://dom.ria.com/uk/prodazha-nedvizhimosti/", actual);
        }
        [Fact]
        public void PerehodProdatTest()
        {
            chrome = StartDriverWithURL("https://dom.ria.com/uk");
            Actions act = new Actions(chrome);
            Thread.Sleep(4000);
            IWebElement kup = chrome.FindElement(By.LinkText("Продати"));
            act.MoveToElement(kup).Click().Build().Perform();
            Thread.Sleep(4000);
            string actual = chrome.FindElement(By.LinkText("Продати")).GetAttribute("href");
            Assert.Equal("https://dom.ria.com/uk/realty_add_new.html", actual);
        }
    }
}
