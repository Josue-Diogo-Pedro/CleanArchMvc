namespace CleanArchMvc.Domain.Entities;

public sealed class Product
{
    public int ProductId { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; set; }
    public string? Image { get; private set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    private void ValidateDomain()
    {

    }
}
