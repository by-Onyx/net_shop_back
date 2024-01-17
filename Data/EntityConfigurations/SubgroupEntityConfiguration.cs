using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using net_shop_back.Entities;

namespace net_shop_back.Data.EntityConfigurations;

public class SubgroupEntityConfiguration : IEntityTypeConfiguration<Subgroup>
{
    public void Configure(EntityTypeBuilder<Subgroup> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Group)
            .WithMany()
            .HasForeignKey(p => p.GroupId);

        builder.Property(p => p.Name)
            .HasMaxLength(255);
        
        builder.Property(p => p.SubgroupPhotoLink)
            .HasMaxLength(1000);
    }
}