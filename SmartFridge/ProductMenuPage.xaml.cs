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
    /// Логика взаимодействия для ProductMenuPage.xaml
    /// </summary>
    public partial class ProductMenuPage : Window
    {
        public ProductMenuPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ProductsListPage window = new ProductsListPage(1);
            window.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ProductsListPage window = new ProductsListPage(2);
            window.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ProductsListPage window = new ProductsListPage(3);
            window.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ProductsListPage window = new ProductsListPage(4);
            window.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            ProductsListPage window = new ProductsListPage(5);
            window.Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            ProductsListPage window = new ProductsListPage(6);
            window.Show();
        }


        private void button7_Click(object sender, RoutedEventArgs e)
        {
            ProductsListPage window = new ProductsListPage(7);
            window.Show();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            ProductsListPage window = new ProductsListPage(8);
            window.Show();
        }
    }
}
