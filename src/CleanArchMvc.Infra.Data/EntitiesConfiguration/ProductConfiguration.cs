using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(key => key.Id);

        builder.Property(prop => prop.Name).HasMaxLength(100).IsRequired();
        builder.Property(prop => prop.Description).HasMaxLength(200).IsRequired();
        
        builder.Property(prop => prop.Price).HasPrecision(10,2);

        builder.HasOne(prop => prop.Category)
            .WithMany(prop => prop.Products).HasForeignKey(fkey => fkey.CategoryId);
        
    }
}
