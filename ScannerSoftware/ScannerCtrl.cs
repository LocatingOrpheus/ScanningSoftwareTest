using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIA;

namespace ScannerSoftware
{
    public class ScannerCtrl
    {
        public DeviceManager device;
        public DeviceInfo FirstScanner = null;


        public ScannerCtrl()
        {
            device = new DeviceManager();
        }
        /*public List<DeviceManager> ListDevices()
        {
            List<DeviceInfos> lst = device.DeviceInfos;
        }*/
    }
}
