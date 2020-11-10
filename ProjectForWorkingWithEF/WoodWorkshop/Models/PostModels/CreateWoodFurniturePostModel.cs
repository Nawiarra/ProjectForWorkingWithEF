using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WoodWorkshop.Models.PostModels
{
    public class CreateWoodFurniturePostModel
    {
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Date { get; set; }
        public int FurnitureTypeId { get; set; }
        public string Color { get; set; }
        public int WoodTypeId { get; set; }
    }
}
