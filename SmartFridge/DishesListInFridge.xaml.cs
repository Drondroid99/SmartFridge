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
    /// Логика взаимодействия для DishesListInFridge.xaml
    /// </summary>
    public partial class DishesListInFridge : Window
    {
        public ObservableCollection<Recepie> RecipesList { get; set; } = new ObservableCollection<Recepie>();
        public DishesListInFridge()
        {
            InitializeComponent();
            InizializeListofRec();
            list.ItemsSource = RecipesList;
        }
        private async void InizializeListofRec()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
           var sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            string sqlExpression = $"SELECT * FROM [Recepies] WHERE In_Fridge = 'True' ORDER BY Name";

            SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    Recepie recipe = new Recepie(Convert.ToInt32(sqlReader["Id_R"]), Convert.ToString(sqlReader["Name"]),
                         Convert.ToInt32(sqlReader["ExDate"]), Convert.ToInt16(sqlReader["Complexity"]),
                         Convert.ToString(sqlReader["Description"]), Convert.ToInt32(sqlReader["WeightForPortion"]), Convert.ToInt16(sqlReader["Portions"]),
                        Convert.ToInt32(sqlReader["Category"]), Convert.ToString(sqlReader["Image"]),
                        Convert.ToInt32(sqlReader["Time"]), Convert.ToSingle(sqlReader["Proteins"]),
                        Convert.ToSingle(sqlReader["Fats"]), Convert.ToSingle(sqlReader["Carbohydrates"]),
                         Convert.ToSingle(sqlReader["Calories"]),
                        Convert.ToBoolean(sqlReader["In_Fridge"]));

                    RecipesList.Add(recipe);
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
        public Recepie SelectedRecipe { get; set; }
        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = ((sender as ListBox).SelectedItem as Recepie);
            var window = new RecipePage(p.id_R);
            window.Show();
        }
    }
}
