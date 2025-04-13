using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using SystemAutomationTesting.Model;
using SystemAutomationTesting.Model.Tests;

namespace SystemAutomationTesting.ViewModel.Tabs
{
    public class MainTab : BaseTab
    {
        private AllTests _tests;
        public ICommand ProcessSelectedCommand { get; }

        public AllTests Tests
        {
            get => _tests;
            set
            {
                if (_tests != value)
                {
                    _tests = value;
                }
            }
        }

        public MainTab()
        {
            // Initial BaseTab properties
            Name = "Main Tab";
            Description = "This is the main tab for the application.";
            // Initialize the collection of tests0
            Tests = new AllTests();
        }

        public override object CreateContent()
        {
            // Create the main Grid
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Scrollable content
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Button

            // Create the ScrollViewer
            var scrollViewer = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };
            Grid.SetRow(scrollViewer, 0);

            // Create the ItemsControl
            var itemsControl = new ItemsControl
            {
                Margin = new Thickness(10)
            };

            // Bind the ItemsControl to the Tests.Tests collection
            var binding = new Binding("Tests.Tests")
            {
                Source = this,
                Mode = BindingMode.OneWay
            };
            itemsControl.SetBinding(ItemsControl.ItemsSourceProperty, binding);

            // Define the ItemTemplate for the ItemsControl
            var dataTemplate = new DataTemplate(typeof(BaseTest));
            var stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

            // Add a CheckBox to the template
            var checkBoxFactory = new FrameworkElementFactory(typeof(CheckBox));
            checkBoxFactory.SetBinding(CheckBox.ContentProperty, new Binding("Checkbox.Name")); // Bind to the Checkbox name
            checkBoxFactory.SetBinding(CheckBox.IsCheckedProperty, new Binding("Checkbox.IsChecked") { Mode = BindingMode.TwoWay }); // Bind to the Checkbox state
            stackPanelFactory.AppendChild(checkBoxFactory);

            dataTemplate.VisualTree = stackPanelFactory;
            itemsControl.ItemTemplate = dataTemplate;

            // Add the ItemsControl to the ScrollViewer
            scrollViewer.Content = itemsControl;

            // Add the ScrollViewer to the Grid
            grid.Children.Add(scrollViewer);

            // Create a Button to process selected items
            var processButton = new Button
            {
                Content = "Process Selected",
                HorizontalAlignment = HorizontalAlignment.Center,
                Height = 40,
                Width = 150,
                Margin = new Thickness(10)
            };
            var commandBinding = new Binding("ProcessSelectedCommand")
            {
                Source = this
            };
            processButton.SetBinding(Button.CommandProperty, commandBinding);
            Grid.SetRow(processButton, 1);
            grid.Children.Add(processButton);

            return grid;
        }

        public IEnumerable<BaseTest> GetSelectedTests()
        {
            return Tests.Tests.Where(test => test.Checkbox.IsChecked == true);
        }

        private void ProcessSelected()
        {
            var selectedTests = GetSelectedTests();

            // Process the selected tests
            foreach (var test in selectedTests)
            {
                Debug.WriteLine($"Processing test: {test.TestName}");
                // Add your processing logic here
            }
        }

    }
}
