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
using WpfProjektWirtualnyTaksometr.Modele;

namespace WpfProjektWirtualnyTaksometr.Views
{
    /// <summary>
    /// Interaction logic for KlientWindow.xaml
    /// </summary>
    public partial class KlientWindow : Window
    {
        public KlientWindow()
        {
            InitializeComponent();
        }
        private void ZamowTaxi_Click(object sender, RoutedEventArgs e)
        {
            var klient = new Klient
            {
                Imie = ImieTextBox.Text,
                Nazwisko = NazwiskoTextBox.Text,
                Telefon = TelefonTextBox.Text,
                Email = EmailTextBox.Text,
                MiejsceStartu = MiejsceOdbioruTextBox.Text,
                DataZamowienia = DateTime.Now
            };
            ZamowienieStatusText.Text = "✅ Taxi zostało zamówione!";
            ZamowienieStatusText.Foreground = new SolidColorBrush(Colors.LimeGreen);

            ImieTextBox.Text = "";
            NazwiskoTextBox.Text = "";
            TelefonTextBox.Text = "";
            EmailTextBox.Text = "";
            MiejsceOdbioruTextBox.Text = "";
        }
    }
}