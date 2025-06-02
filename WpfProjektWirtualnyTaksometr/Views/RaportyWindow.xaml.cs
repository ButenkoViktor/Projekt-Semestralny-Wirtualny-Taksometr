using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfProjektWirtualnyTaksometr.BazaDanych;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using static System.Collections.Specialized.BitVector32;

namespace WpfProjektWirtualnyTaksometr.Views
{
    /// <summary>
    /// Interaction logic for RaportyWindow.xaml
    /// </summary>
    public partial class RaportyWindow : Window
    {
        public RaportyWindow()
        {
            InitializeComponent();
            ZaladujRaporty();
        }

        private void ZaladujRaporty()
        {
            using (var context = new TaksometrDbContext())
            {
                var raporty = context.Zlecenie
                    .OrderByDescending(z => z.Data)
                    .Select(z => new
                    {
                        z.Data,
                        KlientFullName = z.Klient.Imie + " " + z.Klient.Nazwisko,
                        KierowcaFullName = z.Kierowca.Imie + " " + z.Kierowca.Nazwisko,
                        z.AdresPoczatkowy,
                        z.AdresKoncowy,
                        z.Kilometraz,
                        z.Cena,
                        z.Taryfa
                    })
                    .ToList();

                ZleceniaDataGrid.ItemsSource = raporty;
            }
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtr = SearchTextBox.Text.ToLower();

            using (var context = new TaksometrDbContext())
            {
                var raporty = context.Zlecenie
                    .Where(z => (z.Kierowca.Imie + " " + z.Kierowca.Nazwisko).ToLower().Contains(filtr))
                    .OrderByDescending(z => z.Data)
                    .Select(z => new
                    {
                        z.Data,
                        KlientFullName = z.Klient.Imie + " " + z.Klient.Nazwisko,
                        KierowcaFullName = z.Kierowca.Imie + " " + z.Kierowca.Nazwisko,
                        z.AdresPoczatkowy,
                        z.AdresKoncowy,
                        z.Kilometraz,
                        z.Cena,
                        z.Taryfa
                    })
                    .ToList();

                ZleceniaDataGrid.ItemsSource = raporty;
            }
        }

        private void EksportujDoPdf_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new TaksometrDbContext())
            {
                var raporty = context.Zlecenie
                    .OrderByDescending(z => z.Data)
                    .Select(z => new
                    {
                        z.Data,
                        Klient = z.Klient.Imie + " " + z.Klient.Nazwisko,
                        Kierowca = z.Kierowca.Imie + " " + z.Kierowca.Nazwisko,
                        z.AdresPoczatkowy,
                        z.AdresKoncowy,
                        z.Kilometraz,
                        z.Cena,
                        z.Taryfa
                    })
                    .ToList();

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Document (*.pdf)|*.pdf",
                    FileName = "RaportZlecen.pdf"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    var doc = new Document();
                    var section = doc.AddSection();

                    section.PageSetup.Orientation = MigraDoc.DocumentObjectModel.Orientation.Landscape;

                    var paragraph = section.AddParagraph("Raport Zleceń");
                    paragraph.Format.Font.Size = 14;
                    paragraph.Format.Font.Bold = true;
                    paragraph.Format.SpaceAfter = "0.5cm";
                    paragraph.Format.Alignment = ParagraphAlignment.Center;

                    var table = section.AddTable();
                    table.Borders.Width = 0.5;

                    string[] headers = { "Data", "Klient", "Kierowca", "Start", "Koniec", "KM", "Cena (zł)", "Taryfa" };

                    var widths = new double[] { 3, 3, 3, 4, 4, 2, 2.5, 2 };

                    foreach (var width in widths)
                    {
                        var col = table.AddColumn(Unit.FromCentimeter(width));
                        col.Format.Alignment = ParagraphAlignment.Left;
                    }

                    var headerRow = table.AddRow();
                    headerRow.Format.Font.Bold = true;
                    headerRow.Format.Font.Size = 9;

                    for (int i = 0; i < headers.Length; i++)
                    {
                        headerRow.Cells[i].AddParagraph(headers[i]);
                        headerRow.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                        headerRow.Cells[i].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
                    }

                    foreach (var r in raporty)
                    {
                        var row = table.AddRow();
                        row.Format.Font.Size = 8;
                        row.Format.Alignment = ParagraphAlignment.Left;

                        row.Cells[0].AddParagraph(r.Data.ToString("g"));
                        row.Cells[1].AddParagraph(r.Klient);
                        row.Cells[2].AddParagraph(r.Kierowca);
                        row.Cells[3].AddParagraph(r.AdresPoczatkowy);
                        row.Cells[4].AddParagraph(r.AdresKoncowy);
                        row.Cells[5].AddParagraph(r.Kilometraz.ToString());
                        row.Cells[6].AddParagraph(r.Cena.ToString("0.00 zł"));
                        row.Cells[7].AddParagraph(r.Taryfa.ToString());

                        for (int i = 0; i < row.Cells.Count; i++)
                            row.Cells[i].Format.Alignment = ParagraphAlignment.Left;
                    }

                    var renderer = new PdfDocumentRenderer(true)
                    {
                        Document = doc
                    };
                    renderer.RenderDocument();
                    renderer.PdfDocument.Save(saveFileDialog.FileName);

                    MessageBox.Show("Eksport do PDF zakończony sukcesem!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
