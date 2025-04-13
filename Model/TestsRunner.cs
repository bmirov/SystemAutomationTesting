using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace SystemAutomationTesting.Model
{
    class TestsRunner
    {
        private List<BaseTest> _selectedTests;
        private List<Device> _devices;

        public TestsRunner(List<BaseTest> selectedTests, List<Device> devices)
        {
            _selectedTests = selectedTests;
            _devices = devices;
        }

        // Optional: Add methods to interact with the test objects
        public List<BaseTest> GetTestObjects()
        {
            return _selectedTests;
        }

        public void RunTests()
        {
            foreach (var device in _devices)
            {
                Debug.WriteLine($"Device Index: {device.DeviceIndex}, Device Type: {device.DeviceType}, Parameter: {device.Parameter}, Value: {device.Value}");
            }
            foreach (var selectedTest in _selectedTests)
            {
                Debug.WriteLine($"Selected Test: {selectedTest.TestName}, Is Checked: {selectedTest.Checkbox.IsChecked}");
                //try
                //{
                //    // Get the type of the class with the same name as the selectedTest.Name
                //    var type = Type.GetType($"SystemAutomationTesting.Model.{selectedTest.Name}");

                //    if (type == null)
                //    {
                //        Debug.WriteLine($"Class '{selectedTest.Name}' not found.");
                //        throw new InvalidOperationException($"Class '{selectedTest.Name}' not found in the namespace 'SystemAutomationTesting.Model'.");
                //    }

                //    // Define the arguments to pass to the constructor
                //    object[] constructorArgs = { /* Add your arguments here */ };

                //    // Dynamically create an instance of the class with the arguments
                //    var instance = Activator.CreateInstance(type, constructorArgs);

                //    // Optional: Call a method on the instance if needed
                //    Debug.WriteLine($"Successfully created an instance of {type.Name}");
                //}
                //catch (Exception ex)
                //{
                //    Debug.WriteLine($"Error instantiating class '{selectedTest.Name}': {ex.Message}");
                //    throw;
                //}
            }
        }
    }
}
