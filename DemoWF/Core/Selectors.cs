namespace DemoWF.Core
{
    using NUnit.Framework;
    using System.Collections;
    using System.Collections.Generic;

    public static class Selectors
    {
        #region DatePickerTest
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

        #endregion

        #region ComboBoxTest
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

        #endregion

        #region AjaxBoxTest
        public static IDictionary<string, string> AjaxCheckBox()
        {
            var selector = new Dictionary<string, string>()
            {
                { "Container", "[class='awe-display o-ochk']" },
                { "All Checkboxes", "#ContentPlaceHolder1_ChildMeal1" },
            };

            return selector;
        }

        public static IDictionary<string, int> Type()
        {
            var selector = new Dictionary<string, int>()
            {
                { "Celery", 183 },
                { "Broccoli", 185 },
                { "Artichoke", 187 },
                { "Cauliflower", 189 },
                { "Lettuce", 191 },
            };

            return selector;
        }

        public static string Vegetable(int vegetableType)
        {
            return $"[class='awe-ajaxcheckboxlist-field awe-field'] [value='{vegetableType}']";
        }

        #endregion

        #region GridTest

        public static IDictionary<string, string> Grid()
        {
            var selector = new Dictionary<string, string>()
            {
                { "Container", "#ContentPlaceHolder1_Grid1" },
                { "Page Size", "#ContentPlaceHolder1_Grid1PageSize-awed" },
                { "100", "#ContentPlaceHolder1_Grid1PageSize-dropmenu [data-val='100']" },
                { "Last Page", "#ContentPlaceHolder1_Grid1 [data-p='8']" },
                { "First Row", "[data-k=\"601\"]" },
            };

            return selector;
        }

        #endregion
    }
}