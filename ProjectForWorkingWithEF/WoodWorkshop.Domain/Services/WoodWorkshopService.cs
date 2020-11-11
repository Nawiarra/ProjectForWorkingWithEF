﻿using System;
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
using WoodWorkshop.Data;

namespace WoodWorkshop.Domain
{
    public class WoodWorkshopService
    {
        private readonly IWoodWorkshopRepository _woodWorkshopRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly WoodTypeRepository _woodTypeRepository;
        private readonly FurnitureTypeRepository _furnitureTypeRepository;
        private readonly IMapper _mapper;

        public WoodWorkshopService()
        {
            _woodWorkshopRepository = new WoodWorkshopRepository();
            _customerRepository = new CustomerRepository();
            _woodTypeRepository = new WoodTypeRepository(new WoodWorkshopContext());
            _furnitureTypeRepository = new FurnitureTypeRepository(new WoodWorkshopContext());

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

            var customer = _customerRepository.GetById(model.CustomerId);

            if (customer != null)
            {
                var ListsOfEqualsUserFurniture = _woodWorkshopRepository.GetItemsByCustomerAndGroupByDate(customer);

                foreach (var list in ListsOfEqualsUserFurniture)
                {
                    if (list.Count() > 5)
                        throw new System.Exception("Users can't buy more than 5 item's in the same day ");
                }
            }

            var ListOfNonAccessibleWoodType = _woodTypeRepository.GetByName("non-accessible");

            if (ListOfNonAccessibleWoodType != null)
            {

                foreach (var item in ListOfNonAccessibleWoodType)
                {
                    if (model.WoodTypeId == item.Id)
                    {
                        throw new System.Exception("This type of wood is non-accessible for now");
                    }
                }
            }

            var ListOfNonAccessibleFurnitureType = _furnitureTypeRepository.GetByName("non-accessible");

            if (ListOfNonAccessibleFurnitureType != null)
            {

                foreach (var item in ListOfNonAccessibleFurnitureType)
                {
                    if (model.FurnitureTypeId == item.Id)
                    {
                        throw new System.Exception("This type of furniture is non-accessible for now");
                    }
                }
            }

            var woodFurniture = _mapper.Map<WoodFurnitureOrder>(model);

            _woodWorkshopRepository.Create(woodFurniture);

        }

        public WoodFurnitureOrderModel GetItemById(int id)
        {
            var customers = _customerRepository.GetById(id);
     

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
