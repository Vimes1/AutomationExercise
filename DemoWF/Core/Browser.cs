namespace DemoWF.Core
{
    using System;
    using System.Linq;
    using System.Threading;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [Description("Class for Browser initialisation and custom methods to run actions within the tests.")]
    public class Browser
    {
        #region BrowserSetting

        public static Uri PageUri { get; set; }

        private IWebDriver Driver { get; set; } = new ChromeDriver();

        #endregion

        #region CustomMethods

        public void NavigateToUrl(Uri uri)
        {
            Driver.Navigate().GoToUrl(uri);
        }

        public void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
        }

        public IWebElement GetElement(string selector)
        {
            return Driver.FindElement(By.CssSelector(selector));
        }

        public bool GetSelectorStatus(string selector)
        {
            return Driver.FindElements(By.CssSelector(selector)).Any();
        }

        public bool GetDisplayedStatus(string selector)
        {
            return GetElement(selector).Displayed;
        }

        public string GetSelectorText(string selector)
        {
            WaitFor(selector);
            return GetElement(selector).Text;
        }

        public string GetSelectorValue(string selector, bool waitForDisplayed = true)
        {
            WaitFor(selector, waitForDisplayed);
            return GetElement(selector).GetAttribute("value");
        }

        public void ClickElement(string selector)
        {
            WaitFor(selector);
            GetElement(selector).Click();
        }

        public void JQClickElement(params string[] selectors)
        {
            foreach (string selector in selectors)
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", GetElement(selector));
            }
        }

        public void JQScrollTo(string selector)
        {
            IWebElement element = Driver.FindElement(By.CssSelector(selector));
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({inline: 'center'});", GetElement(selector));
        }

        public void AssertText(string selector, string expectedText)
        {
            WaitFor(selector);
            Assert.AreEqual(expectedText, GetSelectorText(selector));
        }

        public void AssertValue(string selector, string expectedText, bool waitForDisplayed = true)
        {
            WaitFor(selector, waitForDisplayed);
            Assert.AreEqual(expectedText, GetSelectorValue(selector, waitForDisplayed));
        }

        public void AssertStatus(string selector, bool waitForDisplayed = true)
        {
            WaitFor(selector, waitForDisplayed);
            Assert.IsTrue(GetSelectorStatus(selector));
        }

        public void WaitFor(string selector, bool waitForDisplayed = true)
        {
            int count = 0;

            while (GetSelectorStatus(selector) == false)
            {
                count++;
                Thread.Sleep(250);

                if (count > 60)
                {
                    throw new NoSuchElementException("Element was not locatable by FindElements within the time limit");
                }
            }

            if (waitForDisplayed)
            {
                if (GetSelectorStatus(selector))
                {
                    if (GetDisplayedStatus(selector) == false)
                    {
                        while (GetDisplayedStatus(selector) == false)
                        {
                            count++;
                            Thread.Sleep(250);

                            if (count > 120)
                            {
                                throw new ElementNotVisibleException("Element was not visible on the page within the time limit");
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}