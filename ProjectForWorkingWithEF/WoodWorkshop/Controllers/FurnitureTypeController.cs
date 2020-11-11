using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Domain.Models;
using WoodWorkshop.Domain.Services;
using WoodWorkshop.Models.PostModels;
using WoodWorkshop.Models.ViewModels;

namespace WoodWorkshop.Controllers
{
    public class FurnitureTypeController
    {
        private readonly FurnitureTypeService _furnitureTypeService;
        private readonly IMapper _mapper;

        public FurnitureTypeController()
        {
            _furnitureTypeService = new FurnitureTypeService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FurnitureTypePostModel, FurnitureTypeModel>().ReverseMap();
                cfg.CreateMap<FurnitureTypeViewModel, FurnitureTypeModel>().ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateWoodFurnitureRequest(FurnitureTypePostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new System.Exception("Invalid name of furniture type");

            var furnitureTypeModel = _mapper.Map<FurnitureTypeModel>(model);

            _furnitureTypeService.CreateFurnitureRequest(furnitureTypeModel);
        }

    }
}
