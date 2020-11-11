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
    public class WoodTypeService
    {
        private readonly WoodTypeRepository _woodTypeRepository;
        private readonly IMapper _mapper;

        public WoodTypeService()
        {
            _woodTypeRepository = new WoodTypeRepository(new WoodWorkshopContext());

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WoodTypeModel, WoodType>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void CreateFurnitureRequest(WoodTypeModel model)
        {

            var existedWoodType = _woodTypeRepository.GetByName(model.TypeName);

            if (existedWoodType != null)
            {
                throw new System.Exception("This wood type has already exist");
            }


            var woodType = _mapper.Map<WoodType>(model);

            _woodTypeRepository.Create(woodType);

        }
    }
}
