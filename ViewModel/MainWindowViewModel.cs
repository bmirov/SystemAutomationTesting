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
using SystemAutomationTesting.Model.Devices;
using System.ComponentModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public ICommand ProcessSelectedCommand { get; }
    public ICommand RunAllTestsCommand { get; } // New command for "Run All Tests"
    public event PropertyChangedEventHandler PropertyChanged;

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

        // Initialize commands
        ProcessSelectedCommand = new RelayCommand(ProcessSelected);
        RunAllTestsCommand = new RelayCommand(RunAllTests); // Initialize the new command
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ProcessSelected()
    {
        // Get selected checkboxes
        var selectedItems = Tests.Where(item => item.Checkbox.IsChecked).ToList();

        // Run tests for selected items
        TestsRunner testsRunner = new TestsRunner(selectedItems);
        testsRunner.RunTests();
    }

    private void RunAllTests() // Method to run all tests
    {
        // Run tests for all items in the Tests collection
        TestsRunner testsRunner = new TestsRunner(Tests.ToList());
        testsRunner.RunTests();
    }
}

