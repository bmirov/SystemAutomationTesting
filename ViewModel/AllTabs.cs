using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SystemAutomationTesting.ViewModel.Tabs;

namespace SystemAutomationTesting.Model
{
    public class AllTabs
    {
        private ObservableCollection<BaseTab> _tabs;
        public ObservableCollection<BaseTab> Tabs
        {
            get => _tabs;
            set
            {
                if (_tabs != value)
                {
                    _tabs = value;
                }
            }
        }

        public AllTabs()
        {
            // Initialize the collection of tests
            Tabs = new ObservableCollection<BaseTab>
            {
                new MainTab(),
                new MainTab(),
                new SettingsTab()
            };
        }
    }
}
