using System.Windows;
using WIA;

namespace ScannerSoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DeviceManager deviceManager;
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
            ScannerCtrl scannerCtrl = new ScannerCtrl();
            scannerCtrl.ScanDoc();
        }
    }
}
