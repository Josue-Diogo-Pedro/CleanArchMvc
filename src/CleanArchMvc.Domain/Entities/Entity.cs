namespace CleanArchMvc.Domain.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }

    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public string? CreateBy { get; set; }
    public string? ModifiedBy { get; set; }
}
