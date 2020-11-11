using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Models;
using WoodWorkshop.Data.Repositories;
using WoodWorkshop.Domain.Models;

namespace WoodWorkshop.Domain.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerModel, Customer>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateFurnitureRequest(CustomerModel model)
        {

            var existedCustomer = _customerRepository.GetByName(model.FullName);

            if (existedCustomer != null)
            {
                throw new System.Exception("This customer has already exist");
            }


            var customer = _mapper.Map<Customer>(model);

            _customerRepository.Create(customer);

        }

    }
}
