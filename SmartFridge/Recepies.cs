using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace SmartFridge
{
    [Table(Name = "Recepies")]
   public class Recepie
    {
        [Column(IsPrimaryKey = true, Storage = "Id_R",IsDbGenerated =true)]
        public int id_R { get; set; }

        [Column(Storage = "Name")]
        public string name { get; set; }

        [Column(Storage = "ExDate")]
        public int exdate { get; set; }

        [Column(Storage = "Complexity")]
        public int complexity { get; set; }

        [Column(Storage = "Description",CanBeNull = true)]
        public string description { get; set; }

        [Column(Storage = "WeigtForPortion")]
        public int weigthfp { get; set; }

        [Column(Storage = "Portion")]
        public int portion { get; set; }

        [Column(Storage = "Category")]
        public int category { get; set; }

        [Column(Storage = "Image",CanBeNull =true)]
        public string image { get; set; }

        [Column(Storage = "Time")]
        public int time { get; set; }

        [Column(Storage = "Proteins")]
        public float proteins { get; set; }

        [Column(Storage = "Fats")]
        public float fats { get; set; }

        [Column(Storage = "Carbohydrates")]
        public float carbohydrates { get; set; }

        [Column(Storage = "Calories")]
        public float calories { get; set; }

        [Column(Storage = "In_fridge")]
        public bool in_fridge { get; set; }

        public Recepie(int id_R,string name, int exdate,int complexity, string description,int weigthfp,int portion,int category,
            string image,int time, float proteins,float fats,float carbohydrates,float calories, bool in_frdge)
        {
            this.id_R = id_R;
            this.name = name;
            this.exdate = exdate;
            this.complexity = complexity;
            this.description = description;
            this.weigthfp = weigthfp;
            this.portion = portion;
            this.category = category;
            this.image = image;
            this.time = time;
            this.proteins = proteins;
            this.fats = fats;
            this.carbohydrates = carbohydrates;
            this.calories = calories;
            this.in_fridge = in_frdge;
        }

        public Recepie()
        {

        }

    }
}
