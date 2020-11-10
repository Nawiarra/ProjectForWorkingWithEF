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
                cfg.CreateMap<WoodFurnitureModel, WoodFurniture>().ReverseMap();
                cfg.CreateMap< WoodTypeModel,WoodType>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateFurnitureRequest(WoodFurnitureModel model)
        {

            var ListOfAllUserRequests = _woodWorkshopRepository.GetAll();

            ListOfAllUserRequests = ListOfAllUserRequests.Where(x => x.FullName == model.FullName).ToList();

            try
            {
                var ListsOfEqualsUserFurniture = ListOfAllUserRequests.GroupBy(x => x.Date);

                foreach (var list in ListsOfEqualsUserFurniture)
                {
                    if (list.Count() > 5)
                        throw new System.Exception("Users can't buy more than 5 item's in the same day ");
                }
            }
            catch(Exception ex)
            {

            }

            var woodFurniture = _mapper.Map<WoodFurniture>(model);

            _woodWorkshopRepository.Create(woodFurniture);

        }

        public WoodFurnitureModel GetItemById(int id)
        {
            var woodFurniture = _woodWorkshopRepository.GetItemById(id);

            return _mapper.Map<WoodFurnitureModel>(woodFurniture);
        }

        public List<WoodFurnitureModel> GetAll()
        {
            var woodFurnitures = _woodWorkshopRepository.GetAll();

            return _mapper.Map<List<WoodFurnitureModel>>(woodFurnitures);
        }

    }
}