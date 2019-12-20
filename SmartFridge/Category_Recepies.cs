using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace SmartFridge
{
    [Table(Name= "Category_Recepies")]
   public class Category_Recepies
    {
        [Column(IsPrimaryKey = true, Storage = "Id_CR", IsDbGenerated = true)]
        public int id_CR { get; set; }

        [Column(Storage = "Name")]
        public string name { get; set; }

        [Column(Storage = "Image")]
        public string image { get; set; }
        
        Category_Recepies()
        {

        }
        Category_Recepies(int id_CR,string name, string image)
        {
            this.id_CR = id_CR;
            this.name = name;
            this.image = image;
        }
    }
}
