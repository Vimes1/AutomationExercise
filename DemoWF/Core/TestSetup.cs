namespace DemoWF
{
    using NUnit.Framework;
    using System;

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