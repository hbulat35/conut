using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConutBackend.Database.Models.Users
{
    public class ModelConfigurations :
        IEntityTypeConfiguration<UserInfo>,
        IEntityTypeConfiguration<UserLink>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasMany(x => x.Links)
                .WithOne(x => x.UserInfo)
                .HasForeignKey(x => x.UserInfoId);
            builder.OwnsOne(x => x.FullName, opt =>
            {
                opt.Property(f => f.FirstName).IsRequired();
                opt.Property(f => f.SurName).IsRequired();
            });
        }

        public void Configure(EntityTypeBuilder<UserLink> builder)
        {
            builder.HasOne(x => x.Link)
                .WithMany()
                .HasForeignKey(x => x.LinkId);
            builder.HasKey(x => new { x.UserInfoId, x.LinkId });
        }
    }
}
