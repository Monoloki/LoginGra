﻿using System;
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
        private string zalogowany1;
        public CharacterSelect(string info)
        {
            zalogowany1 = info;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow characterSelect = new MainWindow();
            characterSelect.Show();
            this.Close();
        }
    }
}
