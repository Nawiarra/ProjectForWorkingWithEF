using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data.Repositories
{
    public class WoodTypeRepository
    {
        private readonly WoodWorkshopContext _ctx;
        public WoodTypeRepository(WoodWorkshopContext context)
        {
            _ctx = context;
        }

        public List<WoodType> FindItemsByName(string name)
        {
            return _ctx.WoodTypes
                .Where(x => x.TypeName.Contains(name))
                .ToList();
        }


    }
}
