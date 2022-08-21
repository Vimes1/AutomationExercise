namespace DemoWF.Core
{
    using System;
    using System.Linq;
    using System.Threading;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class Browser
    {
        #region BrowserSetting

        public static Uri PageUri { get; set; }

        private IWebDriver Driver { get; set; } = new ChromeDriver();

        #endregion

        #region HelperMethods

        public enum FormActions
        {
            ClickElement,
            AssertText,
            AssertStatus,
            AssertValue
        }

        private void ActionSelector(FormActions desiredAction, string selector, string optionalText)
        {
            switch (desiredAction)
            {
                case FormActions.ClickElement:
                    ClickElement(selector);
                    break;
                case FormActions.AssertStatus:
                    AssertStatus(selector);
                    break;
                case FormActions.AssertText:
                    AssertText(selector, optionalText);
                    break;
                case FormActions.AssertValue:
                    AssertValue(selector, optionalText);
                    break;
            }
        }

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

        public string GetSelectorText(string selector)
        {
            return Driver.FindElement(By.CssSelector(selector)).Text;
        }
        public string GetSelectorValue(string selector)
        {
            return Driver.FindElement(By.CssSelector(selector)).GetAttribute("value");
        }

        public bool GetDisplayedStatus(string selector)
        {
            return Driver.FindElement(By.CssSelector(selector)).Displayed;
        }

        public void ClickElement(string selector)
        {
            Driver.FindElement(By.CssSelector(selector)).Click();
        }

        public void AssertText(string selector, string expectedText)
        {
            Assert.AreEqual(expectedText, GetSelectorText(selector));
        }

        public void AssertValue(string selector, string expectedText)
        {
            Assert.AreEqual(expectedText, GetSelectorValue(selector));
        }

        public void AssertStatus(string selector)
        {
            Thread.Sleep(3000);
            Assert.IsTrue(GetSelectorStatus(selector));
        }

        public void WaitFor(string selector)
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

        public void WaitAction(string selector, FormActions desiredAction, string optionalText = "")
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

            ActionSelector(desiredAction, selector, optionalText);
        }

        #endregion
    }
}