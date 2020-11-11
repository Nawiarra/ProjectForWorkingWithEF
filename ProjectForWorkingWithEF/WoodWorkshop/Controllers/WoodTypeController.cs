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
    public class WoodTypeController
    {
        private readonly WoodTypeService _woodTypeService;
        private readonly IMapper _mapper;

        public WoodTypeController()
        {
            _woodTypeService = new WoodTypeService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WoodTypePostModel, WoodTypeModel>().ReverseMap();
                cfg.CreateMap<WoodTypeViewModel, WoodTypeModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateWoodFurnitureRequest(WoodTypePostModel model)
        {

            if (string.IsNullOrWhiteSpace(model.TypeName))
                throw new System.Exception("Invalid type name");

            var woodTypeModel = _mapper.Map<WoodTypeModel>(model);

            _woodTypeService.CreateFurnitureRequest(woodTypeModel);
        }

    }
}
