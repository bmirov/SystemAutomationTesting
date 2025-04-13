using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using SystemAutomationTesting.Model;
using System.Diagnostics;
using System.Text;
using SystemAutomationTesting.Model.Devices;
using SystemAutomationTesting.Model.Tests;
using SystemAutomationTesting.ViewModel.Tabs;
using System.Windows.Controls;


public class MainWindowViewModel
{
    public AllTabs Tabs { get; set; }
    public AllTests AllTests { get; set; }

    public MainWindowViewModel()
    {
        // Initialize command
        
        // Initialize MainTab
        Tabs = new AllTabs();

        // Test Tabs
        AllTests = new AllTests();
    }
}
