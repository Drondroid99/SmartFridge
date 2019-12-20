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
    /// Логика взаимодействия для RecipesMenuPage.xaml
    /// </summary>
    public partial class RecipesMenuPage : Window
    {
        public RecipesMenuPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ListOfRecipes window = new ListOfRecipes(1);
            window.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ListOfRecipes window = new ListOfRecipes(2);
            window.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ListOfRecipes window = new ListOfRecipes(3);
            window.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ListOfRecipes window = new ListOfRecipes(4);
            window.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            ListOfRecipes window = new ListOfRecipes(5);
            window.Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            ListOfRecipes window = new ListOfRecipes(6);
            window.Show();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            ListOfRecipes window = new ListOfRecipes(7);
            window.Show();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            ListOfRecipes window = new ListOfRecipes(8);
            window.Show();
        }
    }
}
