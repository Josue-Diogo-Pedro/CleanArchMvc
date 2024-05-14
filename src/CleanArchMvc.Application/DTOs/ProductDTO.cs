using CleanArchMvc.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Application.DTOs;

public class ProductDTO : EntityDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Image { get; set; }
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
}
