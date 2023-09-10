using UserModel = ConutBackend.Base.Services.Users.Models.DisplayModel;

namespace ConutBackend.Base.Services.Articles.Models
{
    public class SingleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? HtmlContent { get; set; }
        public string Category { get; set; }
        public UserModel Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<CommentModel> Comments { get; set; }
        public string ImageUrl { get; set; }
        public int ViewsCount { get; set; }
        public int CommentsCount { get; set; }
    }
}
