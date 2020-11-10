using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Interfaces;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data.Repositories
{
    public class WoodWorkshopRepository : IWoodWorkshopRepository
    {
        public WoodFurniture Create(WoodFurniture model)
        {
            throw new NotImplementedException();
        }

        public List<WoodFurniture> GetAll()
        {
            throw new NotImplementedException();
        }

        public WoodFurniture GetItemById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
