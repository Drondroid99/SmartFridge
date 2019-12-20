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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Window
    {
        private int Prod_id;
        public ProductPage(int id)
        {
            Prod_id = id;
            InitializeComponent();
            InizializeProduct();
        }
        private async void InizializeProduct()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            string sqlExpression = $"SELECT * FROM [Products] WHERE Id_P = {Prod_id} ORDER BY Name";

            SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {

                    Name.Text = Convert.ToString(sqlReader["Name"]);
                    Category.Text = Convert.ToString(sqlReader["Category"]);
                    Calories.Text = Convert.ToString(sqlReader["Calories"]);
                    Protins.Text = Convert.ToString(sqlReader["Proteins"]);
                    Fats.Text = Convert.ToString(sqlReader["Fats"]);
                    Carbohydrates.Text = Convert.ToString(sqlReader["Carbohydrates"]);


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
