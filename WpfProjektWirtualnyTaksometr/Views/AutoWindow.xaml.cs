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
using WpfProjektWirtualnyTaksometr.BazaDanych;
using WpfProjektWirtualnyTaksometr.Modele;

namespace WpfProjektWirtualnyTaksometr.Views
{
    /// <summary>
    /// Interaction logic for AutoWindow.xaml
    /// </summary>
    public partial class AutoWindow : Window
    {
        public AutoWindow()
        {
            InitializeComponent();
            WczytajAuta();
        }

        private void WczytajAuta()
        {
            using (var context = new TaksometrDbContext())
            {
                var auta = context.Auto.ToList();
                AutoList.ItemsSource = auta;
            }
        }

        private void DodajAuto_Click(object sender, RoutedEventArgs e)
        {
            string marka = MarkaBox.Text.Trim();
            string model = ModelBox.Text.Trim();
            string rejestracja = RejBox.Text.Trim();
            string vin = VinBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(marka) || string.IsNullOrWhiteSpace(model))
            {
                MessageBox.Show("Marka i model są wymagane.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (!string.IsNullOrWhiteSpace(rejestracja) &&
                !System.Text.RegularExpressions.Regex.IsMatch(rejestracja, @"^[A-Z0-9]{4,10}$"))
            {
                MessageBox.Show("Nieprawidłowy numer rejestracyjny. Używaj tylko wielkich liter i cyfr (min 4 znaki).", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            if (!string.IsNullOrWhiteSpace(vin))
            {
                if (vin.Length != 17 || !System.Text.RegularExpressions.Regex.IsMatch(vin, @"^[A-HJ-NPR-Z0-9]{17}$"))
                {
                    MessageBox.Show("Nieprawidłowy VIN. VIN musi mieć dokładnie 17 znaków i nie zawierać liter I, O, Q.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            var noweAuto = new Auto
            {
                Marka = marka,
                Model = model,
                Rejestracja = rejestracja,
                VIN = vin
            };

            using (var context = new TaksometrDbContext())
            {
                context.Auto.Add(noweAuto);
                context.SaveChanges();
            }

            
            WczytajAuta();

          
            MarkaBox.Clear();
            ModelBox.Clear();
            RejBox.Clear();
            VinBox.Clear();

            MessageBox.Show("Auto zostało dodane.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AutoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AutoList.SelectedItem is Auto wybraneAuto)
            {
                
                App.AppState.AktualneAuto = wybraneAuto;
                this.Close();
            }
        }
    }
}