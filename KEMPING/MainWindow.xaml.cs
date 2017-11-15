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
//using System.Windows.Forms;


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

        //private void OnKeyDownHandler(object sender, KeyEventArgs e)
        //{

        //    if (e.Key == Key.Return)
        //    {
        //    }
        //}
        //        private void InitBinding(string imie, string nazwisko, int wiek)
        private void InitBinding()

        {
            //m_oPerson = new Person(1, imie, nazwisko, wiek);
            //plnPersonForm.DataContext = m_oPerson;
            listaPobytow = new List<Pobyt>();
            listaStalych = new List<StalyKlient>();
            siatkaPrzyciskow = new List<Button>();

            listaPobytow.Add(new Pobyt(licznikIdObecnych, "Jan", "Kowalski", "2016-01-01"));
            licznikIdObecnych++;
            listaPobytow.Add(new Pobyt(licznikIdObecnych, "Adam", "Nowak", "2017-03-12"));
            licznikIdObecnych++;
            listaPobytow.Add(new Pobyt(licznikIdObecnych, "Agnieszka", "Kowalczyk", "2016-05-05"));
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
            if ((!Zawiera_Niedozwolone_Znaki(PoleImie.Text) && !Zawiera_Cyfry(PoleImie.Text) && PoleImie.Text != "Imię") &&
                (!Zawiera_Niedozwolone_Znaki(PoleNazwisko.Text) && !Zawiera_Cyfry(PoleNazwisko.Text) && PoleNazwisko.Text != "Nazwisko") &&
                 !Zawiera_Niedozwolone_Znaki(PoleDataP.Text) && PoleDataP.Text != "")
            {
                listaPobytow.Add(new Pobyt(licznikIdObecnych, PoleImie.Text, PoleNazwisko.Text, PoleDataP.Text));
                lstPersons.ItemsSource = null;
                lstPersons.ItemsSource = listaPobytow;
                licznikIdObecnych++;
            }
            else
                MessageBox.Show("Wprowadzono niedozwolone znaki. \nPoprawny przykład:\n\nJan Kowalski 2017-06-31");

        }

        private void Dodaj_Stalego(object sender, RoutedEventArgs e)
        {

            if ((!Zawiera_Niedozwolone_Znaki(PoleImieStalych.Text) && !Zawiera_Cyfry(PoleImieStalych.Text) && PoleImieStalych.Text != "Imię") &&
                (!Zawiera_Niedozwolone_Znaki(PoleNazwiskoStalych.Text) && !Zawiera_Cyfry(PoleNazwiskoStalych.Text) && PoleNazwiskoStalych.Text != "Nazwisko") &&
                (!Zawiera_Niedozwolone_Znaki(PoleIloscPrzyjazdow.Text) && !Zawiera_Litery(PoleIloscPrzyjazdow.Text) && PoleIloscPrzyjazdow.Text != ""))
            
            {
                listaStalych.Add(new StalyKlient(licznikIdObecnych, PoleImieStalych.Text, PoleNazwiskoStalych.Text, Int32.Parse(PoleIloscPrzyjazdow.Text)));
                lstPersonsReg.ItemsSource = null;
                lstPersonsReg.ItemsSource = listaStalych;
                licznikIdObecnych++;
            }
            else
                MessageBox.Show("Wprowadzono niedozwolone znaki. \nPoprawny przykład:\n\nJan Kowalski 1");
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
                    if (siatkaPrzyciskow != null && win2.rezerwacja != null && win2.czyZablokowac == false)
                    {
                        siatkaPrzyciskow[index].Background = Brushes.LightCoral;
                        win2.rezerwacja.IdOsoby = licznikIdObecnych;
                        siatkaPrzyciskow[index].Content = "ZAJĘTY\n" + Convert.ToString(win2.rezerwacja.IdOsoby);
                        listaPobytow.Add(win2.rezerwacja);
                        licznikIdObecnych++;
                        lstPersons.ItemsSource = null;
                        lstPersons.ItemsSource = listaPobytow;
                    }
                    else if (win2.czyZablokowac == true)
                    {
                        siatkaPrzyciskow[index].IsEnabled = false;
                    }


                }
                else
                {
                    int numer = Int32.Parse(WczyZ.Substring(7));

                    OknoSegment win2 = new OknoSegment(listaPobytow[numer].Imie, listaPobytow[numer].Nazwisko, listaPobytow[numer].DataPrzyjazdu);
                    win2.ShowDialog();

                    if (win2.czyZablokowac == true)
                    {
                        siatkaPrzyciskow[index].IsEnabled = false;
                    }

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
            if (!Zawiera_Litery(txtWPionie.Text)  && !Zawiera_Niedozwolone_Znaki(txtWPionie.Text) &&
                !Zawiera_Litery(txtWPoziomie.Text)&& !Zawiera_Niedozwolone_Znaki(txtWPoziomie.Text) )
            { 
                wPionie = Int32.Parse(txtWPionie.Text);
                wPoziomie = Int32.Parse(txtWPoziomie.Text);
                if (wPionie >= 0 && wPoziomie >= 0 && wPionie <= 25 && wPoziomie <= 25)
                {
                    Siatka.Columns = wPionie;
                    Siatka.Rows = wPoziomie;
                    Siatka.Width = wPionie * 50;
                    Siatka.Height = wPoziomie * 50;
                    //siatkaPrzyciskow = new List<Button> siatkaPrzyciskow;
                    //listaPobytow = null;

                    // if (wPionie <= 10 || wPoziomie <= 10)
                    for (j = 0; j < wPionie; j++)
                    {
                        for (i = 0; i < wPoziomie; i++)
                        {
                            Button newBtn = new Button();
                            if (index < 10)
                                newBtn.Content = "00" + Convert.ToString(index) + "\nWOLNE\n" + "0";
                            else if (index > 9 && index < 100)
                                newBtn.Content = "0"  + Convert.ToString(index) + "\nWOLNE\n" + "0";
                            else if (index > 99 && index < 1000)
                                newBtn.Content =        Convert.ToString(index) + "\nWOLNE\n" + "0";
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
                    

            }


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            if (e.Key == Key.Add)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;

        }

        private void zaznaczenie_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void zaznaczenie_2(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private bool Zawiera_Niedozwolone_Znaki(string Tekst)
        {
            bool czyZawiera;

            if (Tekst.Contains("!") ||
                Tekst.Contains("@") ||
                Tekst.Contains("#") ||
                Tekst.Contains("$") ||
                Tekst.Contains("%") ||
                Tekst.Contains("%") ||
                Tekst.Contains("^") ||
                Tekst.Contains("&") ||
                Tekst.Contains("*") ||
                Tekst.Contains("(") ||
                Tekst.Contains(")") ||
                Tekst.Contains("=") ||
                Tekst.Contains("+") ||
                Tekst.Contains("_") ||
                Tekst.Contains("~") ||
                Tekst.Contains("`") ||
                Tekst.Contains("[") ||
                Tekst.Contains("]") ||
                Tekst.Contains("{") ||
                Tekst.Contains("}") ||
                Tekst.Contains("\\") ||
                Tekst.Contains("|") ||
                Tekst.Contains(";") ||
                Tekst.Contains(":") ||
                Tekst.Contains("'") ||
                Tekst.Contains("\"") ||
                Tekst.Contains("<") ||
                Tekst.Contains(">") ||
                Tekst.Contains("?") ||
                Tekst.Contains(",") ||
                Tekst.Contains(".") ||
                Tekst.Contains("/") ||
                Tekst.Contains("€"))
                czyZawiera = true;
            else
                czyZawiera = false;

            return czyZawiera;
        }

        private bool Zawiera_Cyfry(string Tekst)
        {
            bool czyZawiera;

            if (Tekst.Contains("0") ||
                Tekst.Contains("1") ||
                Tekst.Contains("2") ||
                Tekst.Contains("3") ||
                Tekst.Contains("4") ||
                Tekst.Contains("5") ||
                Tekst.Contains("6") ||
                Tekst.Contains("7") ||
                Tekst.Contains("8") ||
                Tekst.Contains("9"))
                czyZawiera = true;
            else
                czyZawiera = false;

            return czyZawiera;
        }

        private bool Zawiera_Litery(string Tekst)
        {
            bool czyZawiera;

            if (Tekst.Contains("q") ||
                Tekst.Contains("w") ||
                Tekst.Contains("e") ||
                Tekst.Contains("r") ||
                Tekst.Contains("t") ||
                Tekst.Contains("y") ||
                Tekst.Contains("u") ||
                Tekst.Contains("i") ||
                Tekst.Contains("o") ||
                Tekst.Contains("p") ||
                Tekst.Contains("a") ||
                Tekst.Contains("s") ||
                Tekst.Contains("d") ||
                Tekst.Contains("f") ||
                Tekst.Contains("g") ||
                Tekst.Contains("h") ||
                Tekst.Contains("j") ||
                Tekst.Contains("k") ||
                Tekst.Contains("l") ||
                Tekst.Contains("z") ||
                Tekst.Contains("x") ||
                Tekst.Contains("c") ||
                Tekst.Contains("v") ||
                Tekst.Contains("b") ||
                Tekst.Contains("n") ||
                Tekst.Contains("m") ||
                Tekst.Contains("Q") ||
                Tekst.Contains("W") ||
                Tekst.Contains("E") ||
                Tekst.Contains("R") ||
                Tekst.Contains("T") ||
                Tekst.Contains("Y") ||
                Tekst.Contains("U") ||
                Tekst.Contains("I") ||
                Tekst.Contains("O") ||
                Tekst.Contains("P") ||
                Tekst.Contains("A") ||
                Tekst.Contains("S") ||
                Tekst.Contains("D") ||
                Tekst.Contains("F") ||
                Tekst.Contains("G") ||
                Tekst.Contains("H") ||
                Tekst.Contains("J") ||
                Tekst.Contains("K") ||
                Tekst.Contains("L") ||
                Tekst.Contains("Z") ||
                Tekst.Contains("X") ||
                Tekst.Contains("C") ||
                Tekst.Contains("V") ||
                Tekst.Contains("B") ||
                Tekst.Contains("N") ||
                Tekst.Contains("M"))
                czyZawiera = true;
            else
                czyZawiera = false;

            return czyZawiera;
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ZakladkaPobyty.IsFocused)
            {
                btnDodajPobyt.Visibility = Visibility.Visible;
                btnDodajStalego.Visibility = Visibility.Hidden;
            }
            else if (ZakladkaStali.IsFocused)
            {
                btnDodajPobyt.Visibility = Visibility.Hidden;
                btnDodajStalego.Visibility = Visibility.Visible;
            }

        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            //lstPersons.Items.Remove(lstPersons.SelectedItem);
            //lstPersons.Items.RemoveAt(lstPersons.SelectedIndex);
            //ItemsControl item = (ItemsControl)lstPersons.SelectedItem;
            //item.Items.RemoveAt(lstPersons.SelectedIndex);
            int index = lstPersons.SelectedIndex;

            listaPobytow.RemoveAt(index);
            lstPersons.ItemsSource = null;
            lstPersons.ItemsSource = listaPobytow;


            //foreach (ItemsControl item in lstPersons.SelectedItems)
            //{ 
            //    lstPersons.Items.Remove(item);
            //}
        }

        //private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        //{
        //    e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
        //    e.DrawText();
        //}
    }



 
}
