using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Domain.Models
{
    public class WoodTypeModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public float BoardThickness { get; set; }
        public string Price { get; set; }
        public virtual ICollection <WoodFurnitureOrderModel> WoodFurnitureOrders { get; set; }
    }
}
