using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using SystemAutomationTesting.Model;

namespace SystemAutomationTesting.ViewModel.Tabs
{
    public class SettingsTab : BaseTab
    {
        public SettingsTab()
        {
            Name = "Settings Tab";
            Description = "This tab contains application settings.";
        }

        public override object CreateContent()
        {
            // Create and return the content for the SettingsTab
            var stackPanel = new StackPanel();
            stackPanel.Children.Add(new TextBlock { Text = "Settings" });
            stackPanel.Children.Add(new Button { Content = "Save Settings" });
            return stackPanel;
        }
    }
}
