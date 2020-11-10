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

        public DbSet <WoodFurniture> WoodPiecesOfFurniture { get; set; }
        public DbSet <WoodType> WoodTypes { get; set; }
    }
}
