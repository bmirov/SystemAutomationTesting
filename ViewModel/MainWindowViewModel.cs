using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using SystemAutomationTesting.Model;
using System.Diagnostics;
using System.Text;

public class Device
{
    public int DeviceIndex { get; set; }
    public string DeviceType { get; set; }
    public string Parameter { get; set; }
    public string Value { get; set; }
}

public class MainWindowViewModel
{
    public ObservableCollection<CheckboxItem> CheckboxItems { get; set; }
    public ICommand ProcessSelectedCommand { get; }
    public ObservableCollection<Device> Devices { get; set; }
    public MainWindowViewModel()
    {

        // Initialize command
        ProcessSelectedCommand = new RelayCommand(ProcessSelected);
        // Initialize checkbox items
        CheckboxItems = new ObservableCollection<CheckboxItem>
            {
                new CheckboxItem { Name = "ALL", IsChecked = false },
                new CheckboxItem { Name = "Test 1", IsChecked = false },
                new CheckboxItem { Name = "Test 2", IsChecked = false }
            };


        // Example data
        Devices = new ObservableCollection<Device>
        {
            new Device { DeviceIndex = 1, DeviceType = "Sensor", Parameter = "Temperature", Value = "25°C" },
            new Device { DeviceIndex = 2, DeviceType = "Actuator", Parameter = "Position", Value = "50%" },
            new Device { DeviceIndex = 3, DeviceType = "Controller", Parameter = "Mode", Value = "Auto" }
        };

    }

    private void ProcessSelected()
    {
        // Get selected checkboxes
        var selectedItems = CheckboxItems.Where(item => item.IsChecked).ToList();
        // Get the updated Devices list
        var updatedDevices = Devices.ToList();

        TestsRunner testsRunner = new TestsRunner(selectedItems, updatedDevices);
        testsRunner.RunTests();
    }


}
