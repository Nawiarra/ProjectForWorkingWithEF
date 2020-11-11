using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data
{
    public class WoodWorkshopContext: DbContext
    {
        public WoodWorkshopContext() : base("Data Source =(LocalDB)\\MSSQLLocalDB;Initial Catalog = MultiLayerExampleDB;Integrated Security=true")
        {

        }
        public WoodWorkshopContext(string connectionString): base(connectionString)
        {

        }

        public DbSet <WoodFurnitureOrder> WoodFurnitureOrders { get; set; }
        public DbSet <FurnitureType> FurnitureTypes { get; set; }
        public DbSet<WoodType> WoodTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
