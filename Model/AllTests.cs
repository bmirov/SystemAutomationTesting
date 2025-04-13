using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemAutomationTesting.Model.Tests;

namespace SystemAutomationTesting.Model
{
    public class AllTests: INotifyPropertyChanged
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

        public AllTests()
        {
            // Initialize the collection of tests
            Tests = new ObservableCollection<BaseTest>
            {
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
                new Test1(),
                new Test2(),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
