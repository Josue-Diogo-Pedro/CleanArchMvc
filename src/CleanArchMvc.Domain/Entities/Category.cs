namespace CleanArchMvc.Domain.Entities;

public sealed class Category
{
    public int CategoryId { get; private set; }
    public string? Name { get; private set; }
    public ICollection<Product> Products { get; set; }

    public Category(string name)
    {
        Name = name;
    }

    public Category(int categoryId, string? name)
    {
        CategoryId = categoryId;
        Name = name;
    }


}
