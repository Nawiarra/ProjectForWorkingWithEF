using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Models.ViewModels
{
    public class WoodFurnitureOrderViewModel
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Date { get; set; }
        public int FurnitureTypeId { get; set; }
        public string Color { get; set; }
        public int WoodTypeId { get; set; }

        public virtual FurnitureTypeViewModel FurnitureType { get; set; }
        public virtual WoodTypeViewModel WoodType { get; set; }
        public virtual CustomerViewModel Customer { get; set; }
    }
}
