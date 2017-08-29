using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required,MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int SellarId { get; set; }
        public User Seller { get; set; }
        public int? BuyerId { get; set; }

        public User Buyer { get; set; }
        public virtual ICollection<Category> Caregories { get; set; }


    }
}
