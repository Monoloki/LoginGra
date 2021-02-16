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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for CharacterSelect.xaml
    /// </summary>
    public partial class CharacterSelect : Window
    {
        private string _zalogowany;
        public CharacterSelect(string info)
        {
            _zalogowany = info;
            InitializeComponent();
            using (var _b = new LoginEntities())
            {
                var _query = _b.Main
                                          .Where(l => l.Login == _zalogowany)
                                          .FirstOrDefault();
                if (_query.NazwaPostaci == null)
                {
                    Nazwa_postaci.Text = "Brak postaci";
                    Nazwa_postaci.IsEnabled = true;
                    Klasa.IsEnabled = true;
                    Frakcja.IsEnabled = true;
                }
                else
                {
                    Nazwa_postaci.Text = _query.NazwaPostaci;
                    Nazwa_postaci.IsEnabled = false;
                    Klasa.Text = Classy(Convert.ToInt32(_query.KlasaID.ToString()));
                    Klasa.IsEnabled = false;
                    Frakcja.Text = Frakcje(Convert.ToInt32(_query.FrakcjaID.ToString()));
                    Frakcja.IsEnabled = false;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow characterSelect = new MainWindow();
            characterSelect.Show();
            this.Close();
        }

        private string Frakcje(int numer)
        {
            string _frakcja;
            switch (numer)
            {
                case 1:
                    return _frakcja = "Dobro";
                case 2:
                    return _frakcja = "Zło";
                default:
                    return _frakcja = "Błąd";
            }
            return _frakcja;
        }

        private string Classy(int numer)
        {
            string _klasa;
            switch (numer)
            {
                case 1:
                    return _klasa = "Mag";
                case 2:
                    return _klasa = "Złodziej";
                case 3:
                    return _klasa = "Wojownik";
                case 4:
                    return _klasa = "Berserker";
                case 5:
                    return _klasa = "Łowca";
                case 6:
                    return _klasa = "Kapłan";
                case 7:
                    return _klasa = "Druid";
                default:
                    return _klasa = "Błąd";
            }
            return _klasa;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var b = new LoginEntities())
            {
                var query = b.Main
                                          .Where(l => l.Login == _zalogowany)
                                          .FirstOrDefault();
                if (query.NazwaPostaci == null)
                {  
                    try
                    {
                        query.NazwaPostaci = Nazwa_postaci.Text;
                        query.KlasaID = Convert.ToInt32(Klasa.Text);
                        query.FrakcjaID = Convert.ToInt32(Frakcja.Text);
                        b.SaveChanges();
                        CharacterSelect characterSelect = new CharacterSelect(_zalogowany);
                        characterSelect.Show();
                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Wpisz Nazwe Postaci ,Numer Klasy oraz Numer Frakcji");
                        throw;
                    } 
                }
                else
                {
                    MessageBox.Show("Istnieje już postać przypisana do tego konta");
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            World characterSelect = new World(_zalogowany);
            characterSelect.Show();
            this.Close();
        }
    }
}
