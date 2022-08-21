namespace DemoWF.Tests
{
    using System;
    using NUnit.Framework;
    using static DemoWF.Core.Browser;
    using static DemoWF.Core.Selectors;

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
        public void DatePickerTest()
        {
            WaitAction(DatePicker()["Field"], FormActions.ClickElement);
            WaitFor(DatePicker()["Container"]);
            WaitAction(DatePicker()["NextButton"], FormActions.ClickElement);
            WaitAction(DatePicker()["15th September"], FormActions.ClickElement);
            WaitAction(DatePicker()["Field /w value"], FormActions.AssertStatus);
        }

        [Test]
        public void ComboBoxTest()
        {
            WaitAction(ComboBox()["DropDown"], FormActions.ClickElement);
            WaitFor(ComboBox()["Container"]);
            WaitAction(ComboBox()["Barley"], FormActions.ClickElement);
            AssertValue(ComboBox()["Field /w value"], "211");
        }

        [Test]
        public void AjaxCheckBoxTest()
        {
            WaitAction(ComboBox()["DropDown"], FormActions.ClickElement);
            WaitFor(ComboBox()["Container"]);
            WaitAction(ComboBox()["Barley"], FormActions.ClickElement);
            AssertValue(ComboBox()["Field /w value"], "211");
        }

        #endregion
    }
}