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
        public WoodFurnitureOrder Create(WoodFurnitureOrder model)
        {
            _ctx.WoodPiecesOfFurniture.Add(model);

            _ctx.SaveChanges();

            return model;
        }

        public List<WoodFurnitureOrder> GetAll()
        {
            return _ctx.WoodPiecesOfFurniture.ToList();
        }

        public WoodFurnitureOrder GetItemById(int id)
        {
            return _ctx.WoodPiecesOfFurniture.FirstOrDefault(x => x.Id == id);
        }

        public List<WoodFurnitureOrder> GetItemsByName(string name)
        {
            return _ctx.WoodPiecesOfFurniture.Where(x => x.FullName == name).ToList();
        }


        public WoodFurnitureOrder UpdateItem(WoodFurnitureOrder model)
        {
            var entity = GetItemById(model.Id);
            entity.Id = model.Id;
            entity.FullName = model.FullName;
            entity.PhoneNumber = model.PhoneNumber;
            entity.Date = model.Date;
            entity.Color = model.Color;
            entity.FurnitureType = model.FurnitureType;
            entity.FurnitureTypeId = model.FurnitureTypeId;
            entity.WoodTypeId = model.WoodTypeId;
            entity.WoodType = model.WoodType;

            _ctx.SaveChanges();

            return model;
        }

        public bool DeleteItem(WoodFurnitureOrder model)
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
