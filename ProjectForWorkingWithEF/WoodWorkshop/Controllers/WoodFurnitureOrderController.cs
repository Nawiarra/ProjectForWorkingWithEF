using System;
using WoodWorkshop.Models.PostModels;
using WoodWorkshop.Domain;
using AutoMapper;
using WoodWorkshop.Domain.Models;
using WoodWorkshop.Models.ViewModels;
using System.Collections.Generic;
using System.Globalization;

namespace WoodWorkshop.Controllers
{
    public class WoodFurnitureOrderController
    {
        private readonly WoodWorkshopService _woodWorkshopService;
        private readonly IMapper _mapper;

        public WoodFurnitureOrderController()
        {
            _woodWorkshopService = new WoodWorkshopService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateWoodFurnitureOrderPostModel, WoodFurnitureOrderModel>();
                cfg.CreateMap<WoodFurnitureOrderModel, WoodFurnitureOrderViewModel>();
                cfg.CreateMap<FurnitureTypePostModel, FurnitureTypeModel>().ReverseMap();
                cfg.CreateMap<FurnitureTypeViewModel, FurnitureTypeModel>().ReverseMap();
                cfg.CreateMap<WoodTypePostModel, WoodTypeModel>().ReverseMap();
                cfg.CreateMap<WoodTypeViewModel, WoodTypeModel>().ReverseMap();
                cfg.CreateMap<CustomerPostModel, CustomerModel>().ReverseMap();
                cfg.CreateMap<CustomerViewModel, CustomerModel>().ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateWoodFurnitureRequest(CreateWoodFurnitureOrderPostModel model)
        {
            DateTime date;

            if (!DateTime.TryParseExact(model.Date, new[] { "yyyy-MM-dd", "MM/dd/yy", "dd-MMM-yy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out date))
            {
                throw new System.Exception("Invalid date format");
            }

            var woodFurnitureModel = _mapper.Map<WoodFurnitureOrderModel>(model);

            _woodWorkshopService.CreateFurnitureRequest(woodFurnitureModel);
        }

        public WoodFurnitureOrderViewModel GetItemById(int id)
        {
            var woodFurnitureModel = _woodWorkshopService.GetItemById(id);

            return _mapper.Map<WoodFurnitureOrderViewModel>(woodFurnitureModel);
        }

        public List<WoodFurnitureOrderViewModel> GetAll()
        {
            var resultItems = _woodWorkshopService.GetAll();

            return _mapper.Map<List<WoodFurnitureOrderViewModel>>(resultItems);
        }

    }
}
