using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace SmartFridge
{
    public class Ingredient : Product
    {
        [Column(Storage = "Quantity")]
        public float quantity { get; set; }

        public Ingredient()
        {

        }

        public Ingredient(int id_P, string name, int category, float proteins, float fats, float carbohydrates, float calories,
            int exdate, string image, bool in_fridge, string description, float quantity)
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
            this.quantity = quantity;
        }
    }
}
