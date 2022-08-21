namespace DemoWF
{
    using System;
    using DemoWF.Core;
    using NUnit.Framework;

    [TestFixture]
    public class Base : Browser
    {
        [OneTimeSetUp]
        public void SetupData()
        {
            Browser.PageUri = new Uri(TestContext.Parameters.Get("TargetUrl"));
        }
    }
}
