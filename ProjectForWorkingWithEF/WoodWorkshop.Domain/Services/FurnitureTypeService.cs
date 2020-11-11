using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data;
using WoodWorkshop.Data.Models;
using WoodWorkshop.Data.Repositories;
using WoodWorkshop.Domain.Models;


namespace WoodWorkshop.Domain.Services
{
    public class FurnitureTypeService
    {
        private readonly FurnitureTypeRepository _furnitureTypeRepository;
        private readonly IMapper _mapper;

        public FurnitureTypeService()
        {
            _furnitureTypeRepository = new FurnitureTypeRepository(new WoodWorkshopContext());

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FurnitureTypeModel, FurnitureType>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateFurnitureRequest(FurnitureTypeModel model)
        {

            var existedFurnitureType = _furnitureTypeRepository.GetByName(model.Name);

            if (existedFurnitureType != null)
            {
                throw new System.Exception("This furniture type has already exist");
            }


            var furnitureType = _mapper.Map<FurnitureType>(model);

            _furnitureTypeRepository.Create(furnitureType);

        }

    }
}
