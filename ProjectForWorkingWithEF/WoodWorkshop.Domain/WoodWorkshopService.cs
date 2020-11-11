using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AutoMapper;
using WoodWorkshop.Data.Models;
using WoodWorkshop.Data.Repositories;
using WoodWorkshop.Domain.Models;
using WoodWorkshop.Data.Interfaces;

namespace WoodWorkshop.Domain
{
    public class WoodWorkshopService
    {
        private readonly IWoodWorkshopRepository _woodWorkshopRepository;
        private readonly IMapper _mapper;

        public WoodWorkshopService()
        {
            _woodWorkshopRepository = new WoodWorkshopRepository();


            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WoodFurnitureOrderModel, WoodFurnitureOrder>().ReverseMap();
                cfg.CreateMap<FurnitureTypeModel, FurnitureType>().ReverseMap();
                cfg.CreateMap<WoodTypeModel, WoodType>().ReverseMap();
                cfg.CreateMap<CustomerModel, Customer>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateFurnitureRequest(WoodFurnitureOrderModel model)
        {

            var ListOfAllItems = _woodWorkshopRepository.GetItemsCustomerId(model.CustomerId);

            if (ListOfAllItems != null)
            {
                var ListsOfEqualsUserFurniture = ListOfAllItems.GroupBy(x => x.Date);

                foreach (var list in ListsOfEqualsUserFurniture)
                {
                    if (list.Count() > 5)
                        throw new System.Exception("Users can't buy more than 5 item's in the same day ");
                }
            }

            var woodFurniture = _mapper.Map<WoodFurnitureOrder>(model);

            _woodWorkshopRepository.Create(woodFurniture);

        }

        public WoodFurnitureOrderModel GetItemById(int id)
        {
            var woodFurniture = _woodWorkshopRepository.GetItemById(id);

            return _mapper.Map<WoodFurnitureOrderModel>(woodFurniture);
        }

        public List<WoodFurnitureOrderModel> GetAll()
        {
            var woodFurnitures = _woodWorkshopRepository.GetAll();

            return _mapper.Map<List<WoodFurnitureOrderModel>>(woodFurnitures);
        }

    }
}
