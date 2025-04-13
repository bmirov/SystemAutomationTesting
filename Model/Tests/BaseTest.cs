using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemAutomationTesting.Model.Devices;
using System.Diagnostics;


namespace SystemAutomationTesting.Model
{
    public class BaseTest
    {
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public string TestResult { get; set; } = "FAIL";
        public CheckboxItem Checkbox { get; set; }
        public CheckboxItem PingDevicesCheckbox { get; set; }
        public virtual bool ShowPingDevicesCheckbox => false;

        public List<string> TestSteps { get; set; } = new List<string>();

        public ObservableCollection<BaseDevice> Devices { get; set; }

        public BaseTest()
        {
            // Initialize the test with default values
            TestName = "Default Test Name";
            TestDescription = "Default Test Description";
            TestResult = "FAIL";
            Checkbox = new CheckboxItem { Name = TestName, IsChecked = false };
            PingDevicesCheckbox = new CheckboxItem { Name = "PingDevices", IsChecked = false };

            TestSteps = new List<string>
            {
                "Step 1: Initialize the test.",
                "Step 2: Execute the test.",
                "Step 3: Validate the results."
            };

            Devices = new ObservableCollection<BaseDevice>();
        }

        public virtual void RunTest()
        {
            Debug.WriteLine($"Running test: {TestName}");
            this.PingDevices();
            foreach (var step in TestSteps)
            {
                Debug.WriteLine(step);
            }
            TestResult = "PASS";
            Debug.WriteLine($"Test result: {TestResult}");
        }

        public void PingDevices()
        {
            foreach (var device in Devices)
            {
                Debug.WriteLine($"Pinging device {device.DeviceIndex} of type {device.DeviceType}\n     {device.Parameter}:{device.Value}");
            }
        }
    }
}
