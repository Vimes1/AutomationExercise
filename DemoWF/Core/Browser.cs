namespace DemoWF.Core
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Timers;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

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

        public bool GetSelectorStatus(string selector)
        {
            return Driver.FindElements(By.CssSelector(selector)).Any();
        }

        public bool GetDisplayedStatus(string selector)
        {
            return Driver.FindElement(By.CssSelector(selector)).Displayed;
        }

        public string GetSelectorText(string selector)
        {
            WaitFor(selector);
            return Driver.FindElement(By.CssSelector(selector)).Text;
        }

        public string GetSelectorValue(string selector, bool waitForDisplayed = true)
        {
            WaitFor(selector, waitForDisplayed);
            return Driver.FindElement(By.CssSelector(selector)).GetAttribute("value");
        }

        public void ClickElement(string selector)
        {
            WaitFor(selector);
            Driver.FindElement(By.CssSelector(selector)).Click();
        }

        public void JQClickElement(params string[] selectors)
        {
            foreach (string selector in selectors)
            {
                IWebElement element = Driver.FindElement(By.CssSelector(selector));
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
            }
        }

        public void JQScrollTo(string selector)
        {
            IWebElement element = Driver.FindElement(By.CssSelector(selector));
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({inline: 'center'});", element);
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