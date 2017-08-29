using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Picture
    {
        //Each picture has title, caption (string) and path on the file system. A picture can be present in many albums. Each photographer can have many albums but an album can have only one owner. 
        public Picture()
        {
            this.Albums = new HashSet<Album>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string PathFile { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
