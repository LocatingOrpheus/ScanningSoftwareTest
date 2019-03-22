using System.Windows;
using WIA;

namespace ScannerSoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ScannerCtrl scanner;
        public MainWindow()
        {
            InitializeComponent();
            scanner = new ScannerCtrl();
        }

        private void GetScannerBtnClick(object sender, RoutedEventArgs e)
        {
            
            //Based off of this guide:
            //https://ourcodeworld.com/articles/read/382/creating-a-scanning-application-in-winforms-with-csharp
            ScannerNameLbl.Content = scanner.GetScannerName();
        }

        private void ScanBtn_Click(object sender, RoutedEventArgs e)
        {
            scanner.ScanImage("scan.jpg");
        }
    }
}
