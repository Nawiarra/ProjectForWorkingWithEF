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
                cfg.CreateMap<CreateWoodFurnitureOrderPostModel, WoodFurnitureOrderModel>();
                cfg.CreateMap<WoodFurnitureOrderModel, WoodFurnitureOrderViewModel> ();
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
            if (string.IsNullOrWhiteSpace(model.Customer.FullName))
                throw new System.Exception("Invalid FullName");
            if (model.Customer.PhoneNumber.Length != 13)
                throw new System.Exception("Invalid Phone Number");

            var woodFurnitureModel = _mapper.Map<WoodFurnitureOrderModel>(model);

            _woodWorkshopService.CreateFurnitureRequest(woodFurnitureModel);
        }

        public WoodFurnitureOrderViewModel GetItemById(int id)
        {
            var woodFurnitureModel = _woodWorkshopService.GetItemById(id);

            return _mapper.Map<WoodFurnitureOrderViewModel>(woodFurnitureModel);
        }

        public List <WoodFurnitureOrderViewModel> GetAll()
        {
            var resultItems = _woodWorkshopService.GetAll() ;

            return _mapper.Map<List<WoodFurnitureOrderViewModel>>(resultItems);
        }

    }
}
