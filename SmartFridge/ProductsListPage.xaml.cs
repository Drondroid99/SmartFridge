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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;


namespace SmartFridge
{
    /// <summary>
    /// Логика взаимодействия для ProductsListPage.xaml
    /// </summary>
    public partial class ProductsListPage : Window
    {
        SqlConnection sqlConnection;
        private int ListType;

        public ProductsListPage()
        {
            InitializeComponent();
            InizializeList();
            list.ItemsSource = ProductList;
        }

        private async void InizializeList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            string sqlExpression = "select * from [Products]";

            /*switch (ListType)
            {
                case 1:
                    sqlExpression = "SELECT * FROM [Products] WHERE Type=N'Мясо' ORDER BY Title";
                    break;
                case 2:
                    sqlExpression = "SELECT * FROM [Products] WHERE Type=N'Морепродукты' ORDER BY Title";
                    break;
                case 3:
                    sqlExpression = "SELECT * FROM [Products] WHERE Type=N'Овощи' ORDER BY Title";
                    break;
                case 4:
                    sqlExpression = "SELECT * FROM [Products] WHERE Type=N'Фрукты' ORDER BY Title";
                    break;
                case 5:
                    sqlExpression = "SELECT * FROM [Products] WHERE Type LIKE N'Молочные%' ORDER BY Title";
                    break;
                case 6:
                    sqlExpression = "SELECT * FROM [Products] WHERE Type LIKE N'Крупы%' ORDER BY Title";
                    break;
                case 7:
                    sqlExpression = "SELECT * FROM [Products] WHERE Type=N'Птица' ORDER BY Title";
                    break;
                case 8:
                    sqlExpression = "SELECT * FROM [Products] WHERE Type LIKE N'Травы%' ORDER BY Title";
                    break;
                case 9:
                    sqlExpression = "SELECT * FROM [Products] WHERE Type=N'Разное' ORDER BY Title";
                    break;
            }*/

            SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    Product product = new Product(Convert.ToInt32(sqlReader["Id_P"]), Convert.ToString(sqlReader["Name"]),
                        Convert.ToInt32(sqlReader["Category"]), Convert.ToSingle(sqlReader["Proteins"]),
                        Convert.ToSingle(sqlReader["Fats"]), Convert.ToSingle(sqlReader["Carbohydrates"]),
                         Convert.ToSingle(sqlReader["Calories"]),
                        Convert.ToInt32(sqlReader["ExDate"]), Convert.ToString(sqlReader["Image"]),
                        Convert.ToBoolean(sqlReader["In_Fridge"]), Convert.ToString(sqlReader["Description"]));

                    ProductList.Add(product);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString(), ex.Source.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        public ObservableCollection<Product> ProductList { get; set; } = new ObservableCollection<Product>();

        public Product SelectedProduct { get; set; }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductPage window = new ProductPage();
            window.Show();
        }
    }
}
