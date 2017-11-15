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

        public OknoSegment(string przekImie, string przekNazw, string przekData)
        {
            InitializeComponent();
            txtImie.Text = przekImie;
            txtNazw.Text = przekNazw;
            txtDat1.Text = przekData;
        }

        private void btnDodajKlienta_Click(object sender, RoutedEventArgs e)
        {
            rezerwacja = new Pobyt(1, txtImie.Text, txtNazw.Text, txtDat1.Text);
            btnDodajKlienta.IsEnabled = false;
            labelDodano.Content = "DODANO.";
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
    }
}
