using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category
{
    public int CategoryId { get; private set; }
    public string? Name { get; private set; }
    public ICollection<Product> Products { get; set; }

    public Category(string name) => ValidateDomain(name);

    public Category(int categoryId, string? name)
    {
        CategoryId = categoryId;
        Name = name;
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

        Name = name;
    }

}
