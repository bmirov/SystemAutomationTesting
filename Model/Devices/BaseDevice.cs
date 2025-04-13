using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemAutomationTesting.Model.Devices
{
    public class BaseDevice
    {
        public int DeviceIndex { get; set; }
        public string DeviceType { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }
    }
}
