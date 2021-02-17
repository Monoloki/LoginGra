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
    /// Okno pozwalające na stworzenie konta z rolą Gracz.
    /// </summary>
    public partial class CreatingAccount : Window
    {
        public CreatingAccount()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var b = new LoginEntities())
            {
                var query = b.Main
                                          .Where(l => l.Login == Login.Text.ToString())
                                          .FirstOrDefault();
                if (query == null)
                {
                    if (Haslo.Text != ReapetHaslo.Text)
                    {
                        MessageBox.Show("Podane Hasła nie są jednakowe");
                    }
                    else
                    {
                        b.Main.Add( new Main {Login=Login.Text,Haslo= Haslo.Text,RolaID=2});
                        b.SaveChanges();
                        using (var b2 = new LoginEntities())
                        {
                            var query2 = b2.Main
                                                      .Where(l => l.Login == Login.Text.ToString())
                                                      .FirstOrDefault();
                            if (query2!=null)
                            {
                                MessageBox.Show("Konto zostało poprawnie stworzone");
                            }
                            else
                            {
                                MessageBox.Show("Wystąpił błąd przy tworzeniu konta");
                            }
                        }
                            
                    }
                }
                else
                {
                    MessageBox.Show("Login zajęty");
                }
            }
        }
    }
}
