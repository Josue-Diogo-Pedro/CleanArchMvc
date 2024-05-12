namespace CleanArchMvc.Application.Products.Commands;

public class ProductRemoveCommand : ProductCommand
{
    public int Id { get; set; }

	public ProductRemoveCommand(int id) => Id = id;
}
