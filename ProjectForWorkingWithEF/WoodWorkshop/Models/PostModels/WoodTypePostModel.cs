using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Models.PostModels
{
    public class WoodTypePostModel
    {
        public string TypeName { get; set; }
        public float BoardThickness { get; set; }
        public string Price { get; set; }
        public virtual ICollection<CreateWoodFurnitureOrderPostModel> WoodFurnitureOrders { get; set; }
    }
}
