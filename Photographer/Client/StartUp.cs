using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;
using TagAttribute;
using System.ComponentModel.DataAnnotations;


namespace Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new PhotoContext();
            context.Database.Initialize(true);

            Tag tag = new Tag()
            {
                Name = "123456789 123456789123456  "
            };

            context.Tags.Add(tag);
            try
            {
                context.SaveChanges();
            }
            catch (ValidationException e)
            {
                tag.Name = _TagTransformer.Transfore(tag.Name);
                context.SaveChanges();
                throw;
            }

            
        }
    }
}
