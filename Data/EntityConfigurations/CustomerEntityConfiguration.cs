using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using net_shop_back.Entities;

namespace net_shop_back.Data.EntityConfigurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100);

            builder.Property(p => p.Mail)
                .HasMaxLength(100);

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(50);
        }
    }
}
