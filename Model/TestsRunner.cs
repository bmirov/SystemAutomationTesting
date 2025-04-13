using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace SystemAutomationTesting.Model
{
    class TestsRunner
    {
        private List<BaseTest> _selectedTests;

        public TestsRunner(List<BaseTest> selectedTests)
        {
            _selectedTests = selectedTests;
        }

        // Optional: Add methods to interact with the test objects
        public List<BaseTest> GetTestObjects()
        {
            return _selectedTests;
        }

        public void RunTests()
        {
            foreach (var selectedTest in _selectedTests)
            {
                Debug.WriteLine($"Selected Test: {selectedTest.TestName}, Is Checked: {selectedTest.Checkbox.IsChecked}");
            }
        }
    }
}
