using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using net_shop_back.Entities;

namespace net_shop_back.Data.EntityConfigurations
{
    public class GroupEntityConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(255);

            builder.Property(p => p.GroupPhotoLink)
                .HasMaxLength(512);
        }
    }
}
