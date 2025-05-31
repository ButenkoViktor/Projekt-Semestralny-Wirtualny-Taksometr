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
    /// Interaction logic for PodsumowanieWindow.xaml
    /// </summary>
    public partial class PodsumowanieWindow : Window
    {
        public PodsumowanieWindow(Klient klient, string adresStart, string adresKoniec, double kilometraz, string taryfa, decimal cena)
        {
            InitializeComponent();

            KlientTextBlock.Text = $"👤 Klient: {klient.Imie} {klient.Nazwisko}";
            AdresStartTextBlock.Text = $"📍 Start: {adresStart}";
            AdresKoniecTextBlock.Text = $"🏁 Koniec: {adresKoniec}";
            DystansTextBlock.Text = $"🚗 Dystans: {kilometraz} km";
            TaryfaTextBlock.Text = $"💼 Taryfa: {taryfa}";
            CenaTextBlock.Text = $"💰 {cena} zł";
        }


        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
