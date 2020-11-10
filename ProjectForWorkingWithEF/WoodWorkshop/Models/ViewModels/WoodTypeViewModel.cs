using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Models.ViewModels
{
    public class WoodTypeViewModel
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public bool Varnish { get; set; }
        public virtual ICollection<WoodFurnitureOrderViewModel> WoodFurnitureOrders { get; set; }
    }
}
