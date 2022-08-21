namespace DemoWF.Core
{
    using NUnit.Framework;
    using System.Collections;
    using System.Collections.Generic;

    public static class Selectors
    {
        public static IDictionary<string, string> DatePicker()
        {
            var selector = new Dictionary<string, string>()
            {
                { "Container", "[class='o-mnth']" },
                { "Field", "#ContentPlaceHolder1_Date1" },
                { "NextButton", "[class='awe-btn o-cmbtn o-mnxt']" },
                { "15th September", "[data-t='1663196400000']" },
                { "Field /w value", "[class='awe-datepicker-field awe-field awe-hasval awe-focus']" }
            };

            return selector;
        }

        public static IDictionary<string, string> ComboBox()
        {
            var selector = new Dictionary<string, string>()
            {
                { "Container", "#ContentPlaceHolder1_AllMealsCombo-dropmenu" },
                { "DropDown", "[class='o-cbxbtn o-ddbtn awe-btn o-btn']" },
                { "Barley", "#ContentPlaceHolder1_AllMealsCombo-dropmenu [data-index='24']" },
                { "Field /w value", "#ContentPlaceHolder1_AllMealsCombo" }
            };

            return selector;
        }

        public static IDictionary<string, string> AjaxCheckBox()
        {
            var selector = new Dictionary<string, string>()
            {
                { "Container", "#ContentPlaceHolder1_AllMealsCombo-dropmenu" },
                { "DropDown", "[class='o-cbxbtn o-ddbtn awe-btn o-btn']" },
                { "Barley", "#ContentPlaceHolder1_AllMealsCombo-dropmenu [data-index='24']" },
                { "Field /w value", "#ContentPlaceHolder1_AllMealsCombo" }
            };

            return selector;
        }
    }
}