using ConutBackend.Base.Services.Abstract;
using ConutBackend.Base.Services.Articles.Models;
using ConutBackend.Database;
using ConutBackend.Database.Models.Articles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Base.Services.Articles
{
    public class GetSingleArticleQuery : GetSingleQueryBase<Article, SingleModel>
    {
        
    }
    public class GetSingleArticleQueryHandler
        : GetSingleQueryHandlerBase<Article, SingleModel, GetSingleArticleQuery>
    {
        public GetSingleArticleQueryHandler(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }

        public override async Task<SingleModel> Handle(GetSingleArticleQuery request, CancellationToken cancellationToken)
        {
            var dbItem = await _databaseContext.Articles
                .Include(x => x.UserInfo)
                .ThenInclude(x => x.Links)
                .ThenInclude(x => x.Link)
                .Include(x => x.Comments)
                .Where(x => x.Id == request.Id)
                .SingleAsync();
            dbItem.ViewsCount++;
            _databaseContext.Update(dbItem);
            await _databaseContext.SaveChangesAsync(cancellationToken);
            return new SingleModel
            {
                Id = dbItem.Id,
                Author = new Users.Models.DisplayModel
                {
                    Description = dbItem.UserInfo.ShortInfo,
                    FullName = dbItem.UserInfo.FullName,
                    ImageUrl = dbItem.UserInfo.ImageUrl,
                    Links = dbItem.UserInfo.Links
                            .Select(l => new Links.Models.DisplayModel
                            {
                                Name = l.Link.Name,
                                ShortName = l.Link.ShortName,
                                Url = l.UserProfileUrl
                            })
                            .ToList(),
                    Professions = dbItem.UserInfo.Professions,
                    Rate = dbItem.UserInfo.Rate,
                    SignImageUrl = dbItem.UserInfo.SignImageUrl,
                },
                ImageUrl = dbItem.ImageUrl,
                Description = dbItem.Description,
                Category = dbItem.Category,
                CommentsCount = dbItem.Comments.Count(),
                CreatedAt = dbItem.CreatedAt,
                HtmlContent = dbItem.HtmlContent,
                Title = dbItem.Title,
                UpdatedAt = dbItem.LastUpdatedAt,
                ViewsCount = dbItem.ViewsCount,
                Comments = dbItem.Comments.Select(c => new CommentModel
                {
                    AuthorName = c.UserName,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    ImageUrl = c.ImageUrl,
                    Id = c.Id,
                })
                        .ToList()
            };
        }

        public override IQueryable<SingleModel> Select(IQueryable<Article> query)
            => throw new NotImplementedException();

    }
}
