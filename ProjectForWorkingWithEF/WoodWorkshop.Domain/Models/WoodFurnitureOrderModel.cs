using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WoodWorkshop.Domain.Models
{
    public class WoodFurnitureOrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Date { get; set; }
        public int FurnitureTypeId { get; set; }
        public string Color { get; set; }
        public int WoodTypeId { get; set; }

        public virtual FurnitureTypeModel FurnitureType { get; set; }
        public virtual WoodTypeModel WoodType { get; set; }
        public virtual CustomerModel Customer { get; set; }

    }
}
