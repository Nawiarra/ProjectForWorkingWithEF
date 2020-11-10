using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Models.PostModels
{
    public class FurnitureTypePostModel
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public bool Varnish { get; set; }
        public virtual ICollection<CreateWoodFurnitureOrderPostModel> WoodFurnitureOrders { get; set; }
    }
}
