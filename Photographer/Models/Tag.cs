using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagAttribute;

namespace Models
{
    public class Tag
    {
        public int Id { get; set; }
        [TagAttribute.Tag]
        public string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
