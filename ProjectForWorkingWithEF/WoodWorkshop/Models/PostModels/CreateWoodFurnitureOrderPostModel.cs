using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WoodWorkshop.Models.PostModels
{
    public class CreateWoodFurnitureOrderPostModel
    {
        public int CustomerId { get; set; }
        public string Date { get; set; }
        public int FurnitureTypeId { get; set; }
        public string Color { get; set; }
        public int WoodTypeId { get; set; }

        public virtual FurnitureTypePostModel FurnitureType { get; set; }
        public virtual WoodTypePostModel WoodType { get; set; }
        public virtual CustomerPostModel Customer{ get; set; }
}
}
