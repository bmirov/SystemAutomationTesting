using System.Collections.ObjectModel;
using System.ComponentModel;
using SystemAutomationTesting.Model.Tests;

namespace SystemAutomationTesting.Model
{
    public class MainTab : INotifyPropertyChanged
    {
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

        public MainTab()
        {
            Tests = new ObservableCollection<BaseTest>
            {
                new Test1(),
                new Test2()
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetAllCheckboxes(bool isChecked)
        {
            foreach (var test in Tests)
            {
                test.Checkbox.IsChecked = isChecked;
            }
        }
    }
}
