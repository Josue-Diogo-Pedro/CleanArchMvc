using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.AutoMapper;

public class DtoToCommandMappingProfile : Profile
{
	public DtoToCommandMappingProfile()
	{
        CreateMap<ProductDTO, ProductCreateCommnad>().ReverseMap();
        CreateMap<ProductDTO, ProductUpdateCommnad>().ReverseMap();
    }
}
