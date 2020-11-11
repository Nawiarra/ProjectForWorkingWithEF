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
   public class CustomerController
    {
        private readonly CustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController()
        {
            _customerService = new CustomerService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerPostModel, CustomerModel>().ReverseMap();
                cfg.CreateMap<CustomerViewModel, CustomerModel>().ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateWoodFurnitureRequest(CustomerPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FullName))
                throw new System.Exception("Invalid FullName");

            if (model.PhoneNumber.Length != 13)
                throw new System.Exception("Invalid Phone Number");

            var customerModel = _mapper.Map<CustomerModel>(model);

            _customerService.CreateFurnitureRequest(customerModel);
        }

    }
}
