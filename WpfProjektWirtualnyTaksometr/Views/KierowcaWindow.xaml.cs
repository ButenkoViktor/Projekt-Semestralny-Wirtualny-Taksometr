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
using System.IO;
using WpfProjektWirtualnyTaksometr.BazaDanych;
using System.Collections.ObjectModel;

namespace WpfProjektWirtualnyTaksometr.Views
{
    /// <summary>
    /// Interaction logic for KierowcaWindow.xaml
    /// </summary>
    public partial class KierowcaWindow : Window
    {
        public Klient? SelectedKlient { get; set; }
        private ObservableCollection<Klient> _dostepniKlienci = new ObservableCollection<Klient>();

        public KierowcaWindow()
        {
            InitializeComponent();
            WyswietlAutoTextBlock();
            WyswietlImieNazwiskoTextBlock();
            ZaladujDostepnychKlientow();
        }

        private string GetSelectedTarifa()
        {
            if (T1.IsChecked == true)
                return "Dzien";
            if (T2.IsChecked == true)
                return "Noc";
            if (T3.IsChecked == true)
                return "Swieta";

            return "Dzien"; 
        }
        private decimal ObliczCene(double kilometraz, string taryfa)
        {
            decimal stawka = taryfa switch
            {
                "Dzien" => 3.9m,
                "Noc" => 4.4m,
                "Swieta" => 5.6m,
                _ => 3.9m
            };

            return (decimal)kilometraz * stawka;
        }
        private void AdresStartTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void WyswietlAutoTextBlock()
        {
            if (App.AppState.AktualneAuto != null)
            {
                var a = App.AppState.AktualneAuto;
                WyswietlAuto.Text = $"{a.Marka} {a.Model} ";
            }
            else
            {
                WyswietlAuto.Text = "";
            }
        }
        private void WyswietlImieNazwiskoTextBlock()
        {
            if (App.AppState.AktualnyKierowca != null)
            {
                var k = App.AppState.AktualnyKierowca;
                WyswietlImieNazwiskoText.Text = $"{k.Imie} {k.Nazwisko}";
                if (!string.IsNullOrEmpty(k.ZdjeciePath) && File.Exists(k.ZdjeciePath))
                {
                    ZdjecieBrush.ImageSource = new BitmapImage(new Uri(k.ZdjeciePath));
                }
            }
            else
            {
                WyswietlImieNazwiskoText.Text = "Brak wybranego kierowcy";
            }
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
            okno.Closed += (s, args) =>
            {
                WyswietlAutoTextBlock();
            };
            okno.Show();

        }
        private void Raporty_Click(object sender, RoutedEventArgs e)
        {
            var okno = new RaportyWindow();
            okno.Show();

        }
        private void ZaladujDostepnychKlientow()
        {

            using (var context = new TaksometrDbContext())
            {
                var klienci = context.Klient
            .Where(k => context.Zlecenie
                .Where(z => z.KlientId == k.Id)
                .All(z => z.Status != StatusZlecenia.WTrakcie && z.Status != StatusZlecenia.Oczekujace))
            .ToList();

                _dostepniKlienci = new ObservableCollection<Klient>(klienci);
                KlientListBox.ItemsSource = _dostepniKlienci;
            }
        }
        private void KlientListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (KlientListBox.SelectedItem is Klient wybranyKlient)
            {
                AdresStartTextBox.Text = wybranyKlient.MiejsceStartu;
                MessageBoxResult result = MessageBox.Show(
                "Klient został wybrany!\n\n✅ Sukces!",
                "Informacja",
                MessageBoxButton.OK);
            }
        }
        private void ZakonczPrzejazd_Click(object sender, RoutedEventArgs e)
        {
            if (App.AppState.AktualnyKierowca == null)
            {
                MessageBox.Show("Nie wybrano kierowcy!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (App.AppState.AktualneAuto == null)
            {
                MessageBox.Show("Nie wybrano auta!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (KlientListBox.SelectedItem is not Klient klient)
            {
                MessageBox.Show("Wybierz klienta!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(KilometrazTextBox.Text, out double kilometraz) || kilometraz <= 0)
            {
                MessageBox.Show("Podaj prawidłowy kilometraż!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string taryfa = GetSelectedTarifa();
            string adresStart = AdresStartTextBox.Text;
            string adresKoniec = AdresKoniecTextBox.Text;
            decimal cena = ObliczCene(kilometraz, taryfa);

            using (var context = new TaksometrDbContext())
            {
                var zlecenie = new Zlecenie
                {
                    KlientId = klient.Id,
                    KierowcaId = App.AppState.AktualnyKierowca.Id,
                    AdresPoczatkowy = adresStart,
                    AdresKoncowy = adresKoniec,
                    Kilometraz = kilometraz,
                    Taryfa = taryfa,
                    Data = DateTime.Now,
                    Cena = cena,
                    Status = StatusZlecenia.Zakonczone
                };

                context.Zlecenie.Add(zlecenie);
                context.SaveChanges();
            }

            new PodsumowanieWindow(klient, adresStart, adresKoniec, kilometraz, taryfa, cena).ShowDialog();
    
            _dostepniKlienci.Remove(klient);

            KlientListBox.SelectedItem = null;
            AdresStartTextBox.Text = "";
            AdresKoniecTextBox.Text = "";
            KilometrazTextBox.Text = "";
        }
    }

}
