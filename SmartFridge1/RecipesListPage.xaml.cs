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
    /// Логика взаимодействия для RecipesListPage.xaml
    /// </summary>
    public partial class RecipesListPage : Window
    {
        public RecipesListPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RecipesMenuPage window = new RecipesMenuPage();
            window.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ListOfRecipes window = new ListOfRecipes();
            window.Show();
        }
    }
}
