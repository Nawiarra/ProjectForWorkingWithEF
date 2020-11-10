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
        private readonly WoodWorkshopContext _ctx;

        public WoodWorkshopRepository()
        {
            _ctx = new WoodWorkshopContext();
        }
        public WoodFurniture Create(WoodFurniture model)
        {
            _ctx.WoodPiecesOfFurniture.Add(model);

            _ctx.SaveChanges();

            return model;
        }

        public List<WoodFurniture> GetAll()
        {
            return _ctx.WoodPiecesOfFurniture.ToList();
        }

        public WoodFurniture GetItemById(int id)
        {
            return _ctx.WoodPiecesOfFurniture.FirstOrDefault(x => x.Id == id);
        }

        public WoodFurniture UpdateItem(WoodFurniture model)
        {
            var entity = GetItemById(model.Id);
            entity.Id = model.Id;
            entity.FullName = model.FullName;
            entity.PhoneNumber = model.PhoneNumber;
            entity.Date = model.Date;
            entity.Color = model.Color;
            entity.WoodType = model.WoodType;
            entity.FurnitureType = model.FurnitureType;

            _ctx.SaveChanges();

            return model;
        }

        public bool DeleteItem(WoodFurniture model)
        {
            try
            {
                var entity = GetItemById(model.Id);

                _ctx.WoodPiecesOfFurniture.Remove(entity);
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
