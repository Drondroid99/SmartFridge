using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace SmartFridge
{
    [Table(Name = "Category_Products")]
    public class Category_Products
    {
        [Column(IsPrimaryKey = true,Storage ="Id_CP",IsDbGenerated =true)]
        public int id_CP { get; set; }

        [Column(Storage = "Name_CP")]
        public string name_cp { get; set; }

        [Column(Storage ="Image_CP")]
        public string image_cp { get; set; }

        Category_Products()
        {

        }
        Category_Products(int id_CP,string name, string image)
        {
            this.id_CP = id_CP;
            this.name_cp = name;
            this.image_cp = image;
        }
        
    }
}
