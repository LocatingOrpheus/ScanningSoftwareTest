using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WIA;

namespace ScannerSoftware
{
    public class ScannerCtrl
    {
        DeviceManager deviceManager;
        DeviceInfo deviceInfo = null;


        public ScannerCtrl()
        {
            deviceManager = new DeviceManager();
        }
        /*public List<DeviceManager> ListDevices()
        {
            List<DeviceInfos> lst = device.DeviceInfos;
        }*/
        public void ScanDoc()
        {
            for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    continue;
                deviceInfo = deviceManager.DeviceInfos[i];
                break;
            }
            var device = deviceInfo.Connect();
            var scannerItem = device.Items[1];
            var imageFile = (ImageFile)scannerItem.Transfer(FormatID.wiaFormatJPEG);
            var path = @"I:\scan.jpg";
            if (File.Exists(path))
                File.Delete(path);
            imageFile.SaveFile(path);
        }
    }
}
