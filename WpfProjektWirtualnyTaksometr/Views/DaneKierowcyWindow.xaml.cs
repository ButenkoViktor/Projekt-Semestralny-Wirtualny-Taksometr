using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using WpfProjektWirtualnyTaksometr.BazaDanych;
using WpfProjektWirtualnyTaksometr.Modele;

namespace WpfProjektWirtualnyTaksometr.Views
{
    /// <summary>
    /// Interaction logic for DaneKierowcyWindow.xaml
    /// </summary>
    public partial class DaneKierowcyWindow : Window
    {
        private string _wybraneZdjeciePath = null!;

        public DaneKierowcyWindow()
        {
            InitializeComponent();
            WczytajKierowcow();
        }

        private void WczytajKierowcow()
        {
            using (var context = new TaksometrDbContext())
            {
                var kierowcy = context.Kierowca.ToList();
                DriverListBox.ItemsSource = kierowcy;
            }
        }

        private void WybierzZdjecie_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Pliki obrazów (*.jpg;*.png)|*.jpg;*.png"
            };

            if (dialog.ShowDialog() == true)
            {
                _wybraneZdjeciePath = dialog.FileName;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(_wybraneZdjeciePath);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                ZdjecieImage.Source = bitmap;
            }
        }
        private void DriverListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (DriverListBox.SelectedItem is Kierowca wybranyKierowca)
            {
                App.AppState.AktualnyKierowca = wybranyKierowca;
      
                var okno = new KierowcaWindow();
                okno.Show();
                this.Close();
            }
        }
        private void ZapiszDaneKierowcy_Click(object sender, RoutedEventArgs e)
        {
            string imie = ImieTextBox.Text.Trim();
            string nazwisko = NazwiskoTextBox.Text.Trim();
            string telefon = TelefonTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko))
            {
                MessageBox.Show("Imię i nazwisko są wymagane.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var kierowca = new Kierowca
            {
                Imie = imie,
                Nazwisko = nazwisko,
                Telefon = telefon,
                Email = email,
                ZdjeciePath = _wybraneZdjeciePath
            };
            

            using (var context = new TaksometrDbContext())
            {
                context.Kierowca.Add(kierowca);
                context.SaveChanges();
            }

            App.AppState.AktualnyKierowca = kierowca;

            MessageBox.Show("Dane kierowcy zapisane.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            var okno = new KierowcaWindow();
            okno.Show();
            this.Close();
        }
    }
}