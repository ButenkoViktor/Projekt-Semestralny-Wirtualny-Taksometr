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
    /// Interaction logic for DaneKierowcyWindow.xaml
    /// </summary>
    public partial class DaneKierowcyWindow : Window
    {
        public DaneKierowcyWindow()
        {
            InitializeComponent();
        }
        public DaneKierowcyWindow(string imie, string nazwisko, string telefon, string email)
        {
            InitializeComponent();
            ImieTextBox.Text = imie;
            NazwiskoTextBox.Text = nazwisko;
            TelefonTextBox.Text = telefon;
            EmailTextBox.Text = email;
        }
        private void ZapiszDaneKierowcy_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
