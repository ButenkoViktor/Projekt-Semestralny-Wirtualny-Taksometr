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
    /// Interaction logic for KierowcaWindow.xaml
    /// </summary>
    public partial class KierowcaWindow : Window
    {
        public Klient? SelectedKlient { get; set; }
        private void KlientListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedKlient = (Klient)KlientListBox.SelectedItem;
        }
        public KierowcaWindow()
        {
            InitializeComponent();
        }
        private string GetSelectedTaryfa()
        {
            if (T1.IsChecked == true) return "Dzien";
            if (T2.IsChecked == true) return "Noc";
            if (T3.IsChecked == true) return "Swieta";
            return "Dzien";
        }
        private decimal ObliczCeneKilometrowa()
        {
            if (!double.TryParse(KilometrazTextBox.Text, out double km))
                return 0;

            string selected = GetSelectedTaryfa();

            decimal stawka = selected switch
            {
                "Dzien" => 3.9m,
                "Noc" => 4.4m,
                "Swieta" => 5.6m,
                _ => 3.9m
            };

            return (decimal)km * stawka;
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
