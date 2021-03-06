﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public User()
        {
            this.SoldProducts = new HashSet<Product>();
            this.BoughtProducts = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        [Required,MinLength(3)]
        public string  LastName { get; set; }
        public int? Age { get; set; }
        public virtual ICollection<Product> SoldProducts { get; set; }
        public virtual ICollection<Product> BoughtProducts { get; set; }
        public virtual ICollection<User> Friends { get; set; }


    }
}
