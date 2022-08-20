namespace DemoWF.Core
{
    using System.Linq;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class Browser
    {
        #region BrowserSetting

        private IWebDriver Driver { get; set; } = new ChromeDriver();

        #endregion

        #region HelperMethods

        public enum FormActions
        {
            ClickElement,
            AssertText
        }

        private void ActionSelector(FormActions desiredAction, string selector, string optionalText)
        {
            switch (desiredAction)
            {
                case FormActions.ClickElement:
                    ClickElement(selector);
                    break;
                case FormActions.AssertText:
                    AssertText(selector, optionalText);
                    break;
            }
        }

        #endregion

        #region CustomMethods
        public bool GetSelectorStatus(string selector)
        {
            return Driver.FindElements(By.CssSelector(selector)).Any();
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
            Driver.FindElement(By.CssSelector(selector)).Click();
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