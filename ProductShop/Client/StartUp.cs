using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data;
using Newtonsoft.Json;

namespace Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //ImportUsers(context);
            ImporProducts(context);
            //ImportCategories();
        }

        private static void ImportCategories()
        {
            string categoriesJson = File.ReadAllText("../../Import/categories.json");
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);
            int number = 0;
            foreach (Category c in categories )
            {


                number++;
            }
        }

        private static void ImporProducts(ProductShopContext context)
        {
            string productJson = File.ReadAllText("C:\\Users\\Iv Velichkova\\Documents\\DB Entity\\ProductShop\\Data\\Import\\products.json");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productJson);
            int number = 0;
            int usersCount = context.Users.Count();
            foreach (Product p in products )
            {
                p.SellarId = (number % usersCount) + 1;
                if (number%3 !=0)
                {
                    p.BuyerId = (number * 2 % usersCount) + 1;
                }
                number++;

            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }


        private static void ImportUsers(ProductShopContext context)
        {
            string userJson = File.ReadAllText("C:\\Users\\Iv Velichkova\\Documents\\DB Entity\\ProductShop\\Data\\Import\\users.json");

            List<User> users = JsonConvert.DeserializeObject<List<User>>(userJson);
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
