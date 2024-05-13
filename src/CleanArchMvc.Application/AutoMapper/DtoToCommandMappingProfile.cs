using AutoMapper;
using CleanArchMvc.Application.Categories.Commnads;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.AutoMapper;

public class DtoToCommandMappingProfile : Profile
{
	public DtoToCommandMappingProfile()
	{
        CreateMap<ProductDTO, ProductCreateCommnad>().ReverseMap();
        CreateMap<ProductDTO, ProductUpdateCommnad>().ReverseMap();

        CreateMap<CategoryDTO, CategoryCreateCommand>().ReverseMap();
        CreateMap<CategoryDTO, CategoryUpdateCommand>().ReverseMap();
    }
}
