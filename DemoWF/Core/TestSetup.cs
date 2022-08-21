namespace DemoWF
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class TestSetup : Base
    {
        public void TestInitialisation(Uri targetPage)
        {
            NavigateToUrl(targetPage);
        }

        public void TestTearDown()
        {
            CloseBrowser();
        }
    }
}