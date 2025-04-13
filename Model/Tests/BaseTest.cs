using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemAutomationTesting.Model
{
    public class BaseTest
    {
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public string TestResult { get; set; } = "FAIL";
        public CheckboxItem Checkbox { get; set; }
        public List<string> TestSteps { get; set; } = new List<string>();

        public BaseTest()
        {
            // Initialize the test with default values
            TestName = "Default Test Name";
            TestDescription = "Default Test Description";
            TestResult = "FAIL";
            Checkbox = new CheckboxItem { Name = TestName, IsChecked = false };
            TestSteps = new List<string>
            {
                "Step 1: Initialize the test.",
                "Step 2: Execute the test.",
                "Step 3: Validate the results."
            };
        }
    }
}
