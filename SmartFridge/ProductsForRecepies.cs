using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace SmartFridge
{
   [Table(Name = "ProductsForRecepies")]
    public class ProductsForRecepies
    {
        [Column(IsPrimaryKey = true,Storage ="Id_Pr",IsDbGenerated = true)]
        public int id_pr { get; set; }

        [Column(IsPrimaryKey = true,Storage = "Id_Re")]
        public int id_re { get; set; }

        [Column(Storage = "Quantity")]
        public float quantity { get; set; }

        ProductsForRecepies()
        {

        }
        ProductsForRecepies(int id_pr,int id_re, float quantity)
        {
            this.id_pr = id_pr;
            this.id_re = id_re;
            this.quantity = quantity;
        }
    }
}
