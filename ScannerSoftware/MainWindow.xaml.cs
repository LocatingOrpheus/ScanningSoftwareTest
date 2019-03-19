using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using WIA;

namespace ScannerSoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DeviceManager deviceManager;
        DeviceInfo deviceInfo = null;
        public MainWindow()
        {
            InitializeComponent();
            deviceManager = new DeviceManager();
        }

        private void GetScannerBtnClick(object sender, RoutedEventArgs e)
        {
            //Based off of this guide:
            //https://ourcodeworld.com/articles/read/382/creating-a-scanning-application-in-winforms-with-csharp
            for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    continue;
                ScannerNameLbl.Content = deviceManager.DeviceInfos[i].Properties["Name"].get_Value();
            }
        }

        private void ScanBtn_Click(object sender, RoutedEventArgs e)
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
