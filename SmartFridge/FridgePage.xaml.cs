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
using System.Configuration;
using System.Data.SqlClient;

namespace SmartFridge
{
    /// <summary>
    /// Логика взаимодействия для FridgePage.xaml
    /// </summary>
    public partial class FridgePage : Window
    {
        public ObservableCollection<Product> ProductList { get; set; } = new ObservableCollection<Product>();

        public FridgePage()
        {
            InitializeComponent();
            InizializeList();
            ProductsInFridge.ItemsSource = ProductList;
        }
        
        private async void InizializeList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            string sqlExpression = $"SELECT * FROM [Products] WHERE In_Fridge = 'True' ORDER BY Name";

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

    }
}

