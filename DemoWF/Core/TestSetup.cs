namespace DemoWF
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    [Description("Class for common test methods to be called by TestFixtures within the Tests folder.")]
    public class TestSetup : Base
    {
        public void TestInitialisation(Uri targetPage)
        {
            NavigateToUrl(targetPage);
        }
    }
}