using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using net_shop_back.Entities;

namespace net_shop_back.Data.EntityConfigurations;

public class DescriptionEntityConfiguration : IEntityTypeConfiguration<ProductDescription>
{
    public void Configure(EntityTypeBuilder<ProductDescription> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Product)
            .WithMany()
            .HasForeignKey(p => p.ProductId);

        builder.Property(p => p.Header)
            .HasMaxLength(100);

        builder.Property(p => p.Text)
            .HasMaxLength(2000);
    }
}