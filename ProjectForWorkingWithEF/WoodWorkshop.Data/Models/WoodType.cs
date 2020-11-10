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
        public string TypeName { get; set; }
        public float BoardThickness { get; set; }
        public string Price { get; set; }
        public virtual ICollection<WoodFurnitureOrder> WoodFurnitureOrders { get; set; }
    }
}
