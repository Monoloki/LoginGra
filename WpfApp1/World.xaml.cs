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
    /// Interaction logic for World.xaml
    /// </summary>
    public partial class World : Window
    {
        private string _zalogowany;
        public World(string nazwa)
        {
            InitializeComponent();
            _zalogowany = nazwa;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CharacterSelect characterSelect = new CharacterSelect(_zalogowany);
            characterSelect.Show();
            this.Close();
        }
    }
}
