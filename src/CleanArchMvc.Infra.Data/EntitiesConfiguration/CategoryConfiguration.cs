using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(key => key.Id);
        builder.Property(prop => prop.Name).HasMaxLength(100).IsRequired();

        builder.HasData(
            new Category(1, "Material Escolar"),
            new Category(2, "Eletrônicos"),
            new Category(3, "Acessórios")
            );

    }
}
