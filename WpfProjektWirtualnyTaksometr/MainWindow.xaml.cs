using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfProjektWirtualnyTaksometr.Views;

namespace WpfProjektWirtualnyTaksometr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void KlientClick(object sender, RoutedEventArgs e)
        {
            var okno = new KlientWindow();
            okno.Show();
            this.Close(); 
        }

        private void KierowcaClick(object sender, RoutedEventArgs e)
        {
            var okno = new KierowcaWindow();
            okno.Show();
            this.Close(); 
        }
    }
}