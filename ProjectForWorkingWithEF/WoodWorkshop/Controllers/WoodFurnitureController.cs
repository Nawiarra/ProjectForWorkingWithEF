using System;
using WoodWorkshop.Models.PostModels;
using WoodWorkshop.Domain;
using AutoMapper;
using WoodWorkshop.Domain.Models;
using WoodWorkshop.Models.ViewModels;
using System.Collections.Generic;

namespace WoodWorkshop.Controllers
{
    public class WoodFurnitureController
    {
        private readonly WoodWorkshopService _woodWorkshopService;
        private readonly IMapper _mapper;

        public WoodFurnitureController()
        {
            _woodWorkshopService = new WoodWorkshopService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateWoodFurniturePostModel, WoodFurnitureModel>();
                cfg.CreateMap<WoodFurnitureModel, WoodFurnitureViewModel> ();
                cfg.CreateMap<FurnitureTypePostModel, FurnitureTypeModel>().ReverseMap();
                cfg.CreateMap<FurnitureTypeViewModel, FurnitureTypeModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateWoodFurnitureRequest(CreateWoodFurniturePostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FullName))
                throw new System.Exception("Invalid FullName");
            if (model.PhoneNumber.Length != 13)
                throw new System.Exception("Invalid Phone Number");

            var woodFurnitureModel = _mapper.Map<WoodFurnitureModel>(model);

            _woodWorkshopService.CreateFurnitureRequest(woodFurnitureModel);
        }

        public WoodFurnitureViewModel GetItemById(int id)
        {
            var woodFurnitureModel = _woodWorkshopService.GetItemById(id);

            return _mapper.Map<WoodFurnitureViewModel>(woodFurnitureModel);
        }

        public List <WoodFurnitureViewModel> GetAll()
        {
            var resultItems = _woodWorkshopService.GetAll() ;

            return _mapper.Map<List<WoodFurnitureViewModel>>(resultItems);
        }

    }
}
