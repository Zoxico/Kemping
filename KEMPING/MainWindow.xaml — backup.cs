using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace KEMPING
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class MainWindow : Window
    {
        private List<Pobyt> listaPobytow = null;
        private List<StalyKlient> listaStalych = null;
        private List<Button> siatkaPrzyciskow = null;
        public int licznikIdObecnych = 0;
        public int licznikIdStalych = 0;
        //public Pobyt rezerwacja = new Pobyt(0, "", "", "");
        //public extern MainWindow(Pobyt rezerwacja);

        public MainWindow()
        {
            InitializeComponent();

            InitBinding();

        }

        //        private void InitBinding(string imie, string nazwisko, int wiek)
        private void InitBinding()

        {
            //m_oPerson = new Person(1, imie, nazwisko, wiek);
            //plnPersonForm.DataContext = m_oPerson;
            listaPobytow = new List<Pobyt>();
            listaStalych = new List<StalyKlient>();
            siatkaPrzyciskow = new List<Button>();

            listaPobytow.Add(new Pobyt(licznikIdObecnych, "Jan", "Kowalski", "31.10.2016"));
            licznikIdObecnych++;
            listaPobytow.Add(new Pobyt(licznikIdObecnych, "Adam", "Nowak", "1.11.2016"));
            licznikIdObecnych++;
            listaPobytow.Add(new Pobyt(licznikIdObecnych, "Agnieszka", "Kowalczyk", "21.10.2016"));
            licznikIdObecnych++;

            listaStalych.Add(new StalyKlient(licznikIdStalych, "Jan", "Kowalski", 2));
            licznikIdStalych++;
            listaStalych.Add(new StalyKlient(licznikIdStalych, "Adam", "Nowak", 1));
            licznikIdStalych++;
            listaStalych.Add(new StalyKlient(licznikIdStalych, "Agnieszka", "Kowalczyk", 0));
            licznikIdStalych++;

            lstPersons.ItemsSource = listaPobytow;
            lstPersonsReg.ItemsSource = listaStalych;
        }

        private void Dodaj_Pobyt(object sender, RoutedEventArgs e)
        {
            listaPobytow.Add(new Pobyt(licznikIdObecnych, PoleImie.Text, PoleNazwisko.Text, PoleDataP.Text));
            lstPersons.ItemsSource = null;
            lstPersons.ItemsSource = listaPobytow;
            licznikIdObecnych++;
        }

        private void Dodaj_Stalego(object sender, RoutedEventArgs e)
        {
            listaStalych.Add(new StalyKlient(licznikIdObecnych, PoleImie.Text, PoleNazwisko.Text, Int32.Parse(PoleIloscPrzyjazdow.Text)));
            lstPersons.ItemsSource = null;
            lstPersons.ItemsSource = listaStalych;
            licznikIdObecnych++;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        { 
            int index = siatkaPrzyciskow.IndexOf((Button)sender);
            string WczyZ = (string)siatkaPrzyciskow[index].Content;
           // int index = WczyZ;
            if (siatkaPrzyciskow != null)
                if ( WczyZ[4] == 'W')
                {
                    OknoSegment win2 = new OknoSegment("Imię", "Nazwisko","Data przyjazdu");
                    win2.ShowDialog();
                    if (siatkaPrzyciskow != null && win2.rezerwacja != null)
                    {
                        siatkaPrzyciskow[index].Background = Brushes.LightCoral;
                        win2.rezerwacja.IdOsoby = licznikIdObecnych;
                        siatkaPrzyciskow[index].Content = "ZAJĘTY\n" + Convert.ToString(win2.rezerwacja.IdOsoby);
                    }
                    
                    listaPobytow.Add(win2.rezerwacja);
                    licznikIdObecnych++;
                    lstPersons.ItemsSource = null;
                    lstPersons.ItemsSource = listaPobytow;

                }
                else
                {
                    int numer = Int32.Parse(WczyZ.Substring(7));

                    OknoSegment win2 = new OknoSegment(listaPobytow[numer].Imie, listaPobytow[numer].Nazwisko, listaPobytow[numer].DataPrzyjazdu);
                    win2.ShowDialog();
                    
                }


            // this.Close();
        }

        private void Odswiez_Obecnych(object sender, RoutedEventArgs e)
        {
            if (radioNazwisko.IsChecked.Value)
            {
                listaPobytow = listaPobytow.OrderBy(x => x.Nazwisko).ToList();
             //   lstPersons.Items.Refresh;
                lstPersons.ItemsSource = null;
                lstPersons.ItemsSource = listaPobytow;

            }
            else if (radioData.IsChecked.Value)
            {
                listaPobytow = listaPobytow.OrderBy(x => x.DataPrzyjazdu).ToList();
                lstPersons.ItemsSource = null;
                lstPersons.ItemsSource = listaPobytow;

            }
            else if (radioId.IsChecked.Value)
            {
                listaPobytow = listaPobytow.OrderBy(x => x.IdOsoby).ToList();
                lstPersons.ItemsSource = null;
                lstPersons.ItemsSource = listaPobytow;

            }
        }

        private void Odswiez_Stalych(object sender, RoutedEventArgs e)
        {
            if (radioNazwisko.IsChecked.Value)
            {
                listaStalych = listaStalych.OrderBy(x => x.Imie).ToList();
                lstPersons.ItemsSource = null;
                lstPersons.ItemsSource = listaStalych;

            }
            else if (radioData.IsChecked.Value)
            {
                listaStalych = listaStalych.OrderBy(x => x.iloscPrzyjazdow).ToList();
                lstPersons.ItemsSource = null;
                lstPersons.ItemsSource = listaStalych;

            }
            else if (radioId.IsChecked.Value)
            {
                listaStalych = listaStalych.OrderBy(x => x.IdOsoby).ToList();
                lstPersons.ItemsSource = null;
                lstPersons.ItemsSource = listaStalych;

            }
        }

        private void Wlacz_Tryb_Jasny(object sender, RoutedEventArgs e)
        {
            // LinearGradientBrush newColors = new LinearGradientBrush 
            
            SolidColorBrush newColor1 = new SolidColorBrush(Color.FromRgb(230,230,230));
            this.Resources["wybranyKolorTla"] = newColor1;
            SolidColorBrush newColor2 = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            this.Resources["wybranyKolorCzcionki"] = newColor2;
            //  this.Foreground = newColor2;
        }

        private void Wlacz_Tryb_Ciemny(object sender, RoutedEventArgs e)
        {
            // LinearGradientBrush newColors = new LinearGradientBrush 

            SolidColorBrush newColor = new SolidColorBrush(Color.FromRgb(50, 50, 50));
            this.Resources["wybranyKolorTla"] = newColor;
            SolidColorBrush newColor2 = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            this.Resources["wybranyKolorCzcionki"] = newColor2;

        }

        private void Zastosuj(object sender, RoutedEventArgs e)
        {
            int wPionie, wPoziomie, i, j, index = 0;
            wPionie   = Int32.Parse(txtWPionie.Text);
            wPoziomie = Int32.Parse(txtWPoziomie.Text);

            if (wPionie <= 10 || wPoziomie <= 10)
                for (j = 0; j < wPionie; j++)
                {
                    for (i = 0; i < wPoziomie; i++)
                    {
                        Button newBtn = new Button();
                        if (index < 10)
                            newBtn.Content = "00" + Convert.ToString(index) + "\nWOLNE\n" + "0";
                        else if (index > 9 && index < 100)
                            newBtn.Content = "0" + Convert.ToString(index) + "\nWOLNE\n" + "0";
                        else if (index > 99 && index < 1000)
                            newBtn.Content = Convert.ToString(index) + "\nWOLNE\n" + "0";
                        else
                            newBtn.Content = "###" + "\nWOLNE\n" + "0";

                        newBtn.Name = "Button" + i.ToString();
                        Siatka.Children.Add(newBtn);
                        Grid.SetRow(newBtn, j);
                        Grid.SetColumn(newBtn, i);
                        if (newBtn != null)
                            siatkaPrzyciskow.Add(newBtn);
                        index++;
                    }
                }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void zaznaczenie_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void zaznaczenie_2(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
    }



 
}
