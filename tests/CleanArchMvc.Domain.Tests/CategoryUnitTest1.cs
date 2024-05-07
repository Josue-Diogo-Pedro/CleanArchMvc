using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create category with valid state")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }
}