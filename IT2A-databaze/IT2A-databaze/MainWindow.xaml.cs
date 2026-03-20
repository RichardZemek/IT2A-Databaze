using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;


namespace IT2A_databaze
{
    public partial class MainWindow : Window
    {
        List<Produkt> produkty = new List<Produkt>();
        int dalsiId = 1;

        public MainWindow()
        {
            InitializeComponent();
            ObnovDataGrid();
        }

        void ObnovDataGrid()
        {
            dgProdukty.ItemsSource = null;
            dgProdukty.ItemsSource = produkty;
        }

        private void Pridat_Click(object sender, RoutedEventArgs e)
        {
            if (tbNazev.Text == "" || tbVyrobce.Text == "")
            {
                MessageBox.Show("Vyplň název a výrobce!");
                return;
            }

            int rok, kusy;

            if (!int.TryParse(tbRok.Text, out rok) || rok < 0)
            {
                MessageBox.Show("Neplatný rok!");
                return;
            }

            if (!int.TryParse(tbKusy.Text, out kusy) || kusy < 0)
            {
                MessageBox.Show("Neplatný počet kusů!");
                return;
            }

            Produkt p = new Produkt()
            {
                Id = dalsiId++,
                Nazev = tbNazev.Text,
                Vyrobce = tbVyrobce.Text,
                RokVyroby = rok,
                Kategorie = tbKategorie.Text,
                PocetKusu = kusy,
                JeDostupny = cbDostupny.IsChecked == true
            };

            produkty.Add(p);
            ObnovDataGrid();
            VymazatForm();
        }

        private void Nacist_Click(object sender, RoutedEventArgs e)
        {
            Produkt p = dgProdukty.SelectedItem as Produkt;
            if (p == null) return;

            tbNazev.Text = p.Nazev;
            tbVyrobce.Text = p.Vyrobce;
            tbRok.Text = p.RokVyroby.ToString();
            tbKategorie.Text = p.Kategorie;
            tbKusy.Text = p.PocetKusu.ToString();
            cbDostupny.IsChecked = p.JeDostupny;
        }

        private void Upravit_Click(object sender, RoutedEventArgs e)
        {
            Produkt p = dgProdukty.SelectedItem as Produkt;
            if (p == null) return;

            p.Nazev = tbNazev.Text;
            p.Vyrobce = tbVyrobce.Text;
            p.RokVyroby = int.Parse(tbRok.Text);
            p.Kategorie = tbKategorie.Text;
            p.PocetKusu = int.Parse(tbKusy.Text);
            p.JeDostupny = cbDostupny.IsChecked == true;

            ObnovDataGrid();
        }

        private void Smazat_Click(object sender, RoutedEventArgs e)
        {
            Produkt p = dgProdukty.SelectedItem as Produkt;
            if (p == null) return;

            if (MessageBox.Show("Opravdu smazat?", "Potvrzení", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                produkty.Remove(p);
                ObnovDataGrid();
            }
        }

        private void Vymazat_Click(object sender, RoutedEventArgs e)
        {
            VymazatForm();
        }

        void VymazatForm()
        {
            tbNazev.Text = "";
            tbVyrobce.Text = "";
            tbRok.Text = "";
            tbKategorie.Text = "";
            tbKusy.Text = "";
            cbDostupny.IsChecked = false;
        }
    }
}