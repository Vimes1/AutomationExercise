namespace DemoWF.Tests
{
    using System;
    using DemoWF.Core;
    using NUnit.Framework;
    using static DemoWF.Core.Browser;

    [TestFixture]
    public class Tests : TestSetup
    {
        #region SetupTeardown

        [SetUp]
        public void Setup()
        {
            TestInitialisation(PageUri);
        }

        [TearDown]
        public void TearDown()
        {
            TestTearDown();
        }

        #endregion

        #region PageTests

        [Test]
        public void DatePicker()
        {
            var bob = "bob";
        }

        #endregion
    }
}