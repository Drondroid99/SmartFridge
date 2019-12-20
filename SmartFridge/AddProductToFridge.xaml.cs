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
    /// Логика взаимодействия для AddProductToFridge.xaml
    /// </summary>
    public partial class AddProductToFridge : Window
    {
        public AddProductToFridge()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
             string sqlExpression = "INSERT INTO Products( Name, Description, Category, Proteins, Fats, Carbohydrates, Calories,ExDate,Image)  VALUES(N'" +
                  Name.Text + "', N'" +
                  null + "', N'" +
                  GetCategoryIdByName(Category.Text) + "', N'" +
                  Convert.ToSingle(Proteins.Text) + "', '" +
                  Convert.ToSingle(Fats.Text) + "', '" +
                  Convert.ToSingle(Carbohydrates.Text) + "', '" +
                  Convert.ToSingle(Calories.Text) + "', '" +
                  Convert.ToInt32(Merge.Text) + "', N'" + null  + "')"
                  ;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                MessageBox.Show ($"Продукт {Name.Text} был добален"); ;
            }
            
        }

        private int GetCategoryIdByName(string name)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlDataReader sqlReader = null;

            string sqlExpression = $"SELECT * FROM [Category_Products] WHERE CP_Name = N'{name}'";

            var command = new SqlCommand(sqlExpression, sqlConnection);

            var id = 0;

            try
            {
                sqlReader = command.ExecuteReader();

                while (sqlReader.Read())
                {
                    id = Convert.ToInt32(sqlReader["Id_CP"]);
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

            return id;
        }
    }
}
