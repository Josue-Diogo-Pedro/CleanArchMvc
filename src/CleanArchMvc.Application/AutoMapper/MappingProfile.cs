using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.AutoMapper;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Category, CategoryDTO>().ReverseMap();
		CreateMap<Product, ProductDTO>().ReverseMap();

		CreateMap<ProductDTO, ProductCreateCommnad>();
		CreateMap<ProductDTO, ProductUpdateCommnad>();
	}
}
