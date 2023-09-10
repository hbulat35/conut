using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConutBackend.Database.Models.Articles
{
    public class ModelConfigurations :
        IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasOne(x => x.UserInfo)
                .WithMany()
                .HasForeignKey(x => x.UserInfoId);
            builder.HasMany(x => x.Comments)
                .WithOne()
                .HasForeignKey(x => x.ArticleId);
        }
    }
}
