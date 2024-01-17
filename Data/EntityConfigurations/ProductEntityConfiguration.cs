using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using net_shop_back.Entities;

namespace net_shop_back.Data.EntityConfigurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Subgroup)
                .WithMany()
                .HasForeignKey(p => p.SubgroupId);

            builder.Property(p => p.Name)
                .HasMaxLength(255);

            builder.Property(p => p.ShortDescription)
                .HasMaxLength(255);
        }
    }
}
