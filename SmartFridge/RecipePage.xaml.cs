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
using System.Configuration;
using System.Data.SqlClient;

namespace SmartFridge
{
    /// <summary>
    /// Логика взаимодействия для RecipePage.xaml
    /// </summary>
    public partial class RecipePage : Window
    {
        private int CategoryId { get; set; }
        public List<Ingredient> IngredientsList { get; set; } = new List<Ingredient>();

        public RecipePage(int id)
        {
            InitializeComponent();
            InitializeRecipe(id);
            InizializeIngredients(id);
            Ingredients.ItemsSource = IngredientsList;
        }

        private async void InitializeRecipe(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            string sqlExpression = $"SELECT * FROM [Recepies] AS r WHERE Id_R = {id}";

            var command = new SqlCommand(sqlExpression, sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {

                    Title.Content = Convert.ToString(sqlReader["Name"]);
                    CategoryId = Convert.ToInt32(sqlReader["Category"]);
                    Difficulty.Content = Convert.ToInt32(sqlReader["Complexity"]);
                    Time.Content = Convert.ToInt32(sqlReader["Time"]);
                    Weight.Content = Convert.ToInt32(sqlReader["WeightForPortion"]);
                    Portions.Content = Convert.ToInt32(sqlReader["Portions"]);
                    ExDate.Content = Convert.ToInt32(sqlReader["ExDate"]);
                    Calories.Content = Convert.ToSingle(sqlReader["Calories"]);
                    Proteins.Content = Convert.ToSingle(sqlReader["Proteins"]);
                    Fats.Content = Convert.ToSingle(sqlReader["Fats"]);
                    Carbo.Content = Convert.ToSingle(sqlReader["Carbohydrates"]);
                    Description.Text = Convert.ToString(sqlReader["Description"]);
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

            InitializeCategory();
        }

        private async void InitializeCategory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            string sqlExpression = $"SELECT * FROM [Category_Recepies] WHERE Id_CR = {CategoryId}";

            var command = new SqlCommand(sqlExpression, sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                   Category.Content = Convert.ToString(sqlReader["Name"]);
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

        private async void InizializeIngredients(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            string sqlExpression = $"SELECT * FROM [ProductsForRecepies] AS pfr LEFT JOIN [Products] as p ON pfr.Id_Pr = p.Id_P WHERE pfr.Id_Re={id} ORDER BY Name";

            var command = new SqlCommand(sqlExpression, sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    var ingr = new Ingredient(Convert.ToInt32(sqlReader["Id_P"]), Convert.ToString(sqlReader["Name"]),
                        Convert.ToInt32(sqlReader["Category"]), Convert.ToSingle(sqlReader["Proteins"]),
                        Convert.ToSingle(sqlReader["Fats"]), Convert.ToSingle(sqlReader["Carbohydrates"]),
                         Convert.ToSingle(sqlReader["Calories"]),
                        Convert.ToInt32(sqlReader["ExDate"]), Convert.ToString(sqlReader["Image"]),
                        Convert.ToBoolean(sqlReader["In_Fridge"]), Convert.ToString(sqlReader["Description"]),
                        Convert.ToSingle(sqlReader["Quantity"]));

                    IngredientsList.Add(ingr);
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
