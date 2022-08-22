namespace DemoWF.Tests
{
    using NUnit.Framework;
    using static DemoWF.Core.Selectors;

    [TestFixture]
    [Description("Test Class running functional tests of the demo-wf page entities.")]
    public class Tests : TestSetup
    {
        #region Setup

        [SetUp]
        public void Setup()
        {
            TestInitialisation(PageUri);
        }

        #endregion

        #region PageTests

        [Test]
        [Description("Navigates to the test page, sets the DatePicker to 15/09/2022 and verifies the result.")]
        public void DatePickerTest()
        {
            // click the DatePicker field and wait for the date value selections to show
            ClickElement(DatePicker()["Field"]);
            AssertStatus(DatePicker()["Container"]);

            // click the next button arrow to move the month to september and select the 15th
            ClickElement(DatePicker()["NextButton"]);
            ClickElement(DatePicker()["15th September"]);

            // assert that the DatePicker fields now shows a value
            AssertStatus(DatePicker()["Field /w value"], waitForDisplayed: false);
        }

        [Test]
        [Description("Navigates to the test page, and sets the ComboBox to Barley and verifies the result.")]
        public void ComboBoxTest()
        {
            // click combo box dropdown and wait for the results to show
            ClickElement(ComboBox()["DropDown"]);
            WaitFor(ComboBox()["Container"]);

            // click the option at the bottom of the list - Barley
            ClickElement(ComboBox()["Barley"]);

            // assert that the field now shows the corresponding value for Barley
            AssertValue(ComboBox()["Field /w value"], "211", waitForDisplayed: false);
        }

        [Test]
        [Description("Navigates to the test page, and checks all the AjaxCheckBox options and verifies the result.")]
        public void AjaxCheckBoxTest()
        {
            // wait for AjaxCheckBox to show on the page
            WaitFor(AjaxCheckBox()["Container"]);

            // uncheck the 2 default selected vegetables
            JQClickElement(
                Vegetable(Type()["Broccoli"]),
                Vegetable(Type()["Artichoke"]));

            // select all vegetables
            JQClickElement(
                Vegetable(Type()["Celery"]),
                Vegetable(Type()["Broccoli"]),
                Vegetable(Type()["Artichoke"]),
                Vegetable(Type()["Cauliflower"]),
                Vegetable(Type()["Lettuce"]));

            // assert that all checkboxes are selected
            AssertValue(AjaxCheckBox()["All Checkboxes"], "[\"183\",\"185\",\"187\",\"189\",\"191\"]", waitForDisplayed: false);
        }

        [Test]
        [Description("Navigates to the test page, scrolls to the Grid, navigates the last page within and verifies the result.")]
        public void GridTest()
        {
            // wait for Grid to show on the page and scroll to it
            WaitFor(Grid()["Container"]);
            JQScrollTo(Grid()["Container"]);

            // click drop-down for page size, click '100'
            JQClickElement(Grid()["Page Size"]);
            JQClickElement(Grid()["100"]);

            // click the last page '8' and assert that the first row shown is the correct value
            ClickElement(Grid()["Last Page"]);
            AssertStatus(Grid()["First Row"], waitForDisplayed: true);
        }

        #endregion
    }
}