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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string zalogowany;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                using (var b = new LoginEntities())
                {
                    var query = b.Main
                                              .Where(l => l.Login == Login1.Text.ToString())
                                              .FirstOrDefault();
                    if (query == null)
                    {
                    MessageBox.Show("Nieprawidłowy Login", "Error");
                    }
                    else
                    {  
                    string y = query.Login;
                    y = String.Concat(y.Where(c => !Char.IsWhiteSpace(c)));
                    if (y == Login1.Text.ToString())
                        {
                        string ea = query.Haslo;
                        ea = String.Concat(ea.Where(c => !Char.IsWhiteSpace(c)));
                        if (ea == Password.Text.ToString())
                            {
                            zalogowany = y;
                            CharacterSelect characterSelect = new CharacterSelect(zalogowany);
                            characterSelect.Show();
                            this.Close();
                            }
                            else
                            {
                            MessageBox.Show("Nieprawidłowe Hasło", "Error");
                            }
                        }
                    }
                }
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreatingAccount creatingAccount = new CreatingAccount();
            creatingAccount.Show();
            this.Close();
        }


    }
}

