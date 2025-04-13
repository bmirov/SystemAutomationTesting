using System.Collections.Generic;

namespace SystemAutomationTesting.Model.Tests
{
    class Test2 : BaseTest
    {
        public Test2()
        {
            // Initialize BaseTest attributes
            TestName = "Test 2";
            TestDescription = "This is a test description for Test 2.";
            TestSteps = new List<string>
            {
                "Step 1: Initialize the test.",
                "Step 2: Execute the test.",
                "Step 3: Validate the results."
            };

            // Initialize checkbox
            Checkbox = new CheckboxItem { Name = TestName, IsChecked = false };
        }
    }
}
