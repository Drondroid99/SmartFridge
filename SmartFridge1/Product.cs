using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace SmartFridge1
{
    [Table(Name = "Products")]
    class Product
    {
        [Column(IsPrimaryKey = true, Storage = "Id_P", IsDbGenerated = true)]
        public int id_P { get; set; }

        [Column(Storage = "Name")]
        public string name { get; set; }

        [Column(Storage = "Category")]
        public int category { get; set; }

        [Column(Storage = "Proteins")]
        public float proteins { get; set; }

        [Column(Storage = "Fats")]
        public float fats { get; set; }

        [Column(Storage = "Carbohydrates")]
        public float carbohydrates { get; set; }

        [Column(Storage = "Calories")]
        public float calories { get; set; }

        [Column(Storage = "ExDate")]
        public int exdate { get; set; }

        [Column(Storage = "Image",CanBeNull = true)]
        public string image { get; set; }

        [Column(Storage = "In_Fridge")]
        public bool in_fridge { get; set; }

        [Column(Storage = "Description", CanBeNull = true)]
        public string description { get; set; }

        public Product()
        {

        }
        public Product(int id_P,string name, int category, float proteins, float fats,float carbohydrates,float calories,
            int exdate,string image,bool in_fridge,string description)
        {
            this.id_P = id_P;
            this.name = name;
            this.category = category;
            this.proteins = proteins;
            this.fats = fats;
            this.carbohydrates = carbohydrates;
            this.calories = calories;
            this.exdate = exdate;
            this.image = image;
            this.in_fridge = in_fridge;
            this.description = description;
            
        }

    }
}
