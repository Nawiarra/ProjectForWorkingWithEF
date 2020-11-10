using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Data.Models
{
    public class WoodType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public bool Varnish { get; set; }
        public virtual ICollection<WoodFurniture> WoodFurnitures { get; set; }
    }
}
