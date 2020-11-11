using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodWorkshop.Data.Repositories
{
    public class FurnitureTypeRepository
    {
        private readonly WoodWorkshopContext _ctx;
        public FurnitureTypeRepository(WoodWorkshopContext context)
        {
            _ctx = context;
        }
    }
}
