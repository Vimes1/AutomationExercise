namespace DemoWF
{
    using DemoWF.Core;
    using NUnit.Framework;

    [SetUpFixture]
    public class Base : Browser
    {
        [OneTimeSetUp]
        public static void SetupData(TestContext context)
        {

        }
    }
}
