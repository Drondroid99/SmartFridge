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


namespace SmartFridge
{
    /// <summary>
    /// Логика взаимодействия для FridgeMenu.xaml
    /// </summary>
    public partial class FridgeMenu : Window
    {
        public FridgeMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            FridgePage window = new FridgePage();
            window.Show();
            //Close();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DishesListInFridge window = new DishesListInFridge();
            window.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            AddProductToFridge window = new AddProductToFridge();
            window.Show();
        }
    }
}
