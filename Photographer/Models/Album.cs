using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Album
    {
        //ach album has name, background color and information whether is public or not. 
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public bool IsPublic { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public int PhotographerId { get; set; }
        public Photographer Photographer { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
       
    }
}
