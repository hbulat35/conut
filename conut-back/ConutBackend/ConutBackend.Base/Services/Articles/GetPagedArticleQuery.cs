using ConutBackend.Base.Services.Abstract;
using ConutBackend.Base.Services.Articles.Models;
using ConutBackend.Database;
using ConutBackend.Database.Models.Articles;

namespace ConutBackend.Base.Services.Articles
{
    public class GetPagedArticleQuery : GetPagedQueryBase<Article, PagedModel, FilterModel>
    {
    }

    public class GetPagedArticleQueryHandler : GetPagedQueryHandlerBase<Article, PagedModel, FilterModel, GetPagedArticleQuery>
    {
        public GetPagedArticleQueryHandler(DatabaseContext databaseContext)
            : base(databaseContext)
        { }

        public override IQueryable<Article> Filter(IQueryable<Article> query, FilterModel filter)
        {
            if (!string.IsNullOrEmpty(filter.Category))
            {
                query = query.Where(x => x.Category.ToLower() == filter.Category.ToLower());
            }
            return query;
        }

        public override IQueryable<PagedModel> Select(IQueryable<Article> query)
            => query.Select(x => new PagedModel
            {
                Category = x.Category,
                CommentsCount = x.Comments.Count(),
                CreatedAt = x.CreatedAt,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                ShortDescription = x.Description.Substring(0, 250) + "…",
                Title = x.Title,
                UpdatedAt = x.LastUpdatedAt,
                Author = new Users.Models.DisplayModel
                {
                    Description = x.UserInfo.ShortInfo,
                    FullName = x.UserInfo.FullName,
                    ImageUrl = x.UserInfo.ImageUrl,
                    Links = x.UserInfo.Links
                        .Select(l => new Links.Models.DisplayModel
                        {
                            Name = l.Link.Name,
                            ShortName = l.Link.ShortName,
                            Url = l.UserProfileUrl
                        })
                        .ToList(),
                    Professions = x.UserInfo.Professions,
                    Rate = x.UserInfo.Rate,
                    SignImageUrl = x.UserInfo.SignImageUrl,
                },
                ViewsCount = x.ViewsCount
            });
    }
}
