using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmartFridge
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            FridgeMenu window = new FridgeMenu();
            window.Show();
            //Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            RecipesListPage window = new RecipesListPage();
            window.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ProductMenuPage window = new ProductMenuPage();
            window.Show();
        }
    }
}
