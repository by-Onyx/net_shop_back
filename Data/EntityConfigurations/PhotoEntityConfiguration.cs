using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using net_shop_back.Entities;

namespace net_shop_back.Data.EntityConfigurations
{
    public class PhotoEntityConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);

            builder.Property(p => p.Link)
                .HasMaxLength(1000);
        }
    }
}
