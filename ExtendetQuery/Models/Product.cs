using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
     
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public virtual  ICollection<Order> Orders { get; set; }
    }
}
