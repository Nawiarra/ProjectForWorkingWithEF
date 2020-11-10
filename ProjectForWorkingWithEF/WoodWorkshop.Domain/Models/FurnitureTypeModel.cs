using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Domain.Models
{
    public class FurnitureTypeModel
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Size { get; set; }
            public bool Varnish { get; set; }
            public virtual ICollection<WoodFurnitureOrderModel> WoodFurnitureOrders { get; set; }
    }
}
