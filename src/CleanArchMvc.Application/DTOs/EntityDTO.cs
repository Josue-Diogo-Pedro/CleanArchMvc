namespace CleanArchMvc.Application.DTOs;

public class EntityDTO
{
    public int Id { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public string? CreateBy { get; set; }
    public string? ModifiedBy { get; set; }
}
