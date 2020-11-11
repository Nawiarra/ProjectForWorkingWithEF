using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data.Repositories
{
    public class FurnitureTypeRepository
    {
        private readonly WoodWorkshopContext _ctx;
        public FurnitureTypeRepository(WoodWorkshopContext context)
        {
            _ctx = context;
        }
        public List<FurnitureType> FindItemsByName(string name)
        {
            return _ctx.FurnitureTypes
                .Where(x => x.Name.Contains(name))
                .ToList();
        }
    }
}
