using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact(DisplayName = "Create product with valid parameters")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }
}
