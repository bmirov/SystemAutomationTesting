using System.Collections.Generic;
using System.Collections.ObjectModel;
using SystemAutomationTesting.Model.Devices;

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

            Devices = new ObservableCollection<BaseDevice>
            {
                new BaseDevice { DeviceIndex = 1, DeviceType = "Sensor2", Parameter = "Temperature", Value = "25°C" },
                new BaseDevice { DeviceIndex = 2, DeviceType = "Actuator", Parameter = "Position", Value = "50%" },
                new BaseDevice { DeviceIndex = 3, DeviceType = "Controller", Parameter = "Mode", Value = "Auto" }
            };
        }
    }
}
