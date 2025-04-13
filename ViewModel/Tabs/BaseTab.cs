using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SystemAutomationTesting.ViewModel.Tabs
{
    public abstract class BaseTab
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public abstract object CreateContent();
        // Property to expose content for WPF binding
        public object Content => CreateContent();
    }
}
