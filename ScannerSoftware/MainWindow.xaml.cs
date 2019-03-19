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
using WIA;

namespace ScannerSoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DeviceManager device;
        public MainWindow()
        {
            InitializeComponent();
            device = new DeviceManager();
        }

        private void GetScannerBtnClick(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= device.DeviceInfos.Count; i++)
            {
                if (device.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    continue;
                ScannerNameLbl.Content = device.DeviceInfos[i].Properties["Name"].get_Value();
            }
        }

        private void ScanBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
