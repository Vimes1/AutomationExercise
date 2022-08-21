namespace DemoWF
{
    using System;
    using DemoWF.Core;
    using NUnit.Framework;

    [Description("Base Class for actioning any settings in the Config.runsettings file and any other Assembly Setup/Teardown activities.")]
    [TestFixture]
    public class Base : Browser
    {
        [OneTimeSetUp]
        public void SetupData()
        {
            Browser.PageUri = new Uri(TestContext.Parameters.Get("TargetUrl"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            CloseBrowser();
        }
    }
}
