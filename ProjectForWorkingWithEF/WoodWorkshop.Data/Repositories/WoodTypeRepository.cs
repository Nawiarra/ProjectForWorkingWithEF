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
        public WoodType Create(WoodType model)
        {
            _ctx.WoodTypes.Add(model);

            _ctx.SaveChanges();

            return model;
        }

        public WoodType GetItemById(int id)
        {
            return _ctx.WoodTypes.FirstOrDefault(x => x.Id == id);
        }

        public bool DeleteItem(WoodType model)
        {
            try
            {
                var entity = GetItemById(model.Id);

                _ctx.WoodTypes.Remove(entity);

                _ctx.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }



    }
}
