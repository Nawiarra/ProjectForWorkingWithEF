using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Models.PostModels
{
    public class CustomerPostModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<CreateWoodFurnitureOrderPostModel> WoodFurnitureOrders { get; set; }
    }
}
