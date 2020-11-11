using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Controllers;
using WoodWorkshop.Models.PostModels;

namespace ProjectForWorkingWithEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new WoodFurnitureController();

            var model = new CreateWoodFurnitureOrderPostModel
            {
                Date = DateTime.UtcNow.ToString("dd.MM.yyyy"),
                FurnitureTypeId = 1,
                Color = "Blue",
                WoodTypeId = 3,

                FurnitureType = new FurnitureTypePostModel
                {
                    Name = "Chair",
                    Size = "50x40x45",
                    Varnish = true
                },

                WoodType = new WoodTypePostModel
                {
                    TypeName = "Acacia",
                    BoardThickness = 10,
                    Price = "50"
                },
                Customer = new CustomerPostModel
                {
                    FullName = "Petr Petrov",
                    PhoneNumber = "+380951111166"
                }

            };

            controller.CreateWoodFurnitureRequest(model);

            var createWoodFurnitureViewModel = controller.GetItemById(0);


            var model2 = new CreateWoodFurnitureOrderPostModel
            {

                Date = DateTime.UtcNow.ToString("dd.MM.yyyy"),
                FurnitureTypeId = 1,
                Color = "Blue",
                WoodTypeId = 2,

                FurnitureType = new FurnitureTypePostModel
                {
                    Name = "Chair",
                    Size = "50x40x45",
                    Varnish = true
                },

                WoodType = new WoodTypePostModel
                {
                    TypeName = "Acacia",
                    BoardThickness = 10,
                    Price = "50"
                },

                Customer = new CustomerPostModel
                {
                    FullName = "Petr Petrov",
                    PhoneNumber = "+380951111166"
                }

            };

            controller.CreateWoodFurnitureRequest(model2);

            var AllItems = controller.GetAll();
        }
    }
}
