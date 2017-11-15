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

namespace KEMPING
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>


    public partial class OknoSegment : Window
    {
        public Pobyt rezerwacja;
        public Pobyt tmp
        {
            get { return rezerwacja; }
            set { }
        }
        public bool czyZablokowac = false;
        public bool tmp_czyZablokowac
        {
            get { return czyZablokowac; }
            set { }
        }

        public OknoSegment(string przekImie, string przekNazw, string przekData)
        {
            InitializeComponent();
            txtImie.Text = przekImie;
            txtNazw.Text = przekNazw;
            txtDat1.Text = przekData;
            if (przekImie != "Imię")
                btnDodajKlienta.IsEnabled = false;
        }

        private void btnDodajKlienta_Click(object sender, RoutedEventArgs e)
        {

            if ((!Zawiera_Niedozwolone_Znaki(txtImie.Text) && !Zawiera_Cyfry(txtImie.Text) && txtImie.Text != "Imię") &&
                (!Zawiera_Niedozwolone_Znaki(txtNazw.Text) && !Zawiera_Cyfry(txtNazw.Text) && txtNazw.Text != "Nazwisko") &&
                 !Zawiera_Niedozwolone_Znaki(txtDat1.Text) && txtDat1.Text != "")
            {
                rezerwacja = new Pobyt(1, txtImie.Text, txtNazw.Text, txtDat1.Text);

                btnDodajKlienta.IsEnabled = false;
                labelDodano.Content = "DODANO.";
            }
            else
                MessageBox.Show("Wprowadzono niedozwolone znaki. \nPoprawny przykład:\n\nJan Kowalski 2017-06-31");

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void zaznaczenie_1(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
 

        private void zaznaczenie_2(object sender, DependencyPropertyChangedEventArgs e)
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

        private void btnWylaczSegment_Click(object sender, RoutedEventArgs e)
        {
            czyZablokowac = true;
            btnDodajKlienta.IsEnabled = false;
            btnWylaczSegment.IsEnabled = false;

            MessageBox.Show("Segment został wyłączony z siatki.");
        }
    }
}
