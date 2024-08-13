using AutoMapper;
using CampusEventMS.Controllers;
using CampusEventMS.Data.Models;
using CampusEventMS.ViewModels;

namespace CampusEventMS
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            // Add the mapping for CategoryCreateDTO and Category
            CreateMap<CategoryCreateDTO, Category>();

            // If you need reverse mapping, uncomment the following line:
            // CreateMap<Category, CategoryCreateDTO>();

        }
    }
}
