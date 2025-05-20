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
using System.Windows.Shapes;

namespace WpfProjektWirtualnyTaksometr.Views
{
    /// <summary>
    /// Interaction logic for KierowcaWindow.xaml
    /// </summary>
    public partial class KierowcaWindow : Window
    {
        public KierowcaWindow()
        {
            InitializeComponent();
        }

        private void AdresStartTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
        }
        private void DaneKierowcy_Click(object sender, RoutedEventArgs e)
        {
            var okno = new DaneKierowcyWindow();
            okno.Show();
           
        }

        private void Auto_Click(object sender, RoutedEventArgs e)
        {
            var okno = new AutoWindow();
            okno.Show();
            
        }
        private void Raporty_Click(object sender, RoutedEventArgs e)
        {
            var okno = new RaportyWindow();
            okno.Show();
           
        }
    }
}
