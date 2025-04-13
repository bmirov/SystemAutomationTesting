using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using SystemAutomationTesting.Model;
using System.Diagnostics;
using System.Text;
using SystemAutomationTesting.Model.Tests;
using System.ComponentModel;

public class Device
{
    public int DeviceIndex { get; set; }
    public string DeviceType { get; set; }
    public string Parameter { get; set; }
    public string Value { get; set; }
}

public class MainWindowViewModel: INotifyPropertyChanged
{
    public ICommand ProcessSelectedCommand { get; }
    public event PropertyChangedEventHandler PropertyChanged;
    public ObservableCollection<Device> Devices { get; set; }

    private ObservableCollection<BaseTest> _tests;
    public ObservableCollection<BaseTest> Tests
    {
        get => _tests;
        set
        {
            if (_tests != value)
            {
                _tests = value;
                OnPropertyChanged(nameof(Tests));
            }
        }
    }

    public MainWindowViewModel()
    {
        Tests = new ObservableCollection<BaseTest>
            {
                new Test1(),
                new Test2()
            };

        // Initialize command
        ProcessSelectedCommand = new RelayCommand(ProcessSelected);

            // Example data
        Devices = new ObservableCollection<Device>
        {
            new Device { DeviceIndex = 1, DeviceType = "Sensor", Parameter = "Temperature", Value = "25°C" },
            new Device { DeviceIndex = 2, DeviceType = "Actuator", Parameter = "Position", Value = "50%" },
            new Device { DeviceIndex = 3, DeviceType = "Controller", Parameter = "Mode", Value = "Auto" }
        };
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ProcessSelected()
    {
        // Get selected checkboxes
        var selectedItems = Tests.Where(item => item.Checkbox.IsChecked).ToList();
        // Get the updated Devices list
        var updatedDevices = Devices.ToList();

        TestsRunner testsRunner = new TestsRunner(selectedItems, updatedDevices);
        testsRunner.RunTests();
    }
}
