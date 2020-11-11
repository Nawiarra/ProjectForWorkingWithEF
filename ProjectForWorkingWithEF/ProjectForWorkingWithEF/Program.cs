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
            var controllerWoodFurnitureOrder = new WoodFurnitureOrderController();
            var controllerFurnitureType = new FurnitureTypeController();
            var controllerWoodType = new WoodTypeController();
            var controllerCustomer = new CustomerController();


            var furnitureType = new FurnitureTypePostModel
            {
                Name = "Chair",
                Size = "50x40x45",
                Varnish = true
            };

            try
            {
                controllerFurnitureType.CreateWoodFurnitureRequest(furnitureType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var woodType = new WoodTypePostModel
            {
                TypeName = "Acacia",
                BoardThickness = 10,
                Price = "50"
            };

            try
            {
                controllerWoodType.CreateWoodFurnitureRequest(woodType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var customer = new CustomerPostModel
            {
                FullName = "Petr Petrov",
                PhoneNumber = "+380951111166"
            };

            try
            {
                controllerCustomer.CreateWoodFurnitureRequest(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var modelWoodFurnitureOrder = new CreateWoodFurnitureOrderPostModel
            {
                Date = DateTime.UtcNow.ToString("dd.MM.yyyy"),
                FurnitureTypeId = 1,
                Color = "Blue",
                WoodTypeId = 3,
                FurnitureType = furnitureType,
                WoodType = woodType,
                Customer = customer

            };



            controllerWoodFurnitureOrder.CreateWoodFurnitureRequest(modelWoodFurnitureOrder);

            var createWoodFurnitureViewModel = controllerWoodFurnitureOrder.GetItemById(0);

            var AllItems = controllerWoodFurnitureOrder.GetAll();
        }
    }
}
