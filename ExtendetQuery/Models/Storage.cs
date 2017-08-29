using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public class Storage
    {
        public Storage()
        {
            this.Product = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
