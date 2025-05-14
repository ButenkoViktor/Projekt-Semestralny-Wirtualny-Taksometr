using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfProjektWirtualnyTaksometr.BazaDanych;
using WpfProjektWirtualnyTaksometr.Modele;

namespace WpfProjektWirtualnyTaksometr.ViewModels
{
    public class KlienciViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Klient> _klienci;
        public ObservableCollection<Klient> Klienci
        {
            get => _klienci;
            set
            {
                _klienci = value;
                OnPropertyChanged();
            }
        }

        // Konstruktor
        public KlienciViewModel()
        {
            WczytajKlientow();
        }

        public void WczytajKlientow()
        {
            using (var context = new AppDbContext(DbContextHelper.Options))
            {
                Klienci = new ObservableCollection<Klient>(context.Klienci.ToList());
            }
        }
    }
}
