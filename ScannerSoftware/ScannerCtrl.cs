using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WIA;
using System.Runtime.InteropServices;

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
        public string GetScannerName()
        {
            for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    continue;
                return deviceManager.DeviceInfos[i].Properties["Name"].get_Value().ToString();
            }
            return "No scanner found";
        }
        public void ScanImage(string path)
        {
            if (path != null)
                path = "scan.jpg";
            try
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
                try
                {
                    var imageFile = (ImageFile)scannerItem.Transfer(FormatID.wiaFormatJPEG);
                    if (File.Exists(path))
                        File.Delete(path);
                    imageFile.SaveFile(path);
                }
                catch (IOException e)
                {
                    throw new IOException("Failed failed to write with error " + e);
                }
            }
            catch (COMException e)
            {
                throw new COMException("Failed to access the scanner with error code " + e);
            }
        }
        public List<ScannerProperties> GetAllScanners()
        {
            List<ScannerProperties> vs = new List<ScannerProperties>();
            try
            {
                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                        continue;
                    ScannerProperties scanner = new ScannerProperties();
                    scanner.ScannerName = (string)deviceManager.DeviceInfos[i].Properties["Name"].get_Value();
                    scanner.ScannerConn = deviceManager.DeviceInfos[i].Properties.ToString();
                    vs.Add(scanner);
                }
            }
            catch
            {

            }
            return vs;
        }
    }
}
