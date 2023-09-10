using ConutBackend.Database.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Database.Models.Articles
{
    public class Article : IModelWithId
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string? HtmlContent { get; set; }
        [Required]
        public string Description { get; set; }
        public UserInfo UserInfo { get; set; }
        public int UserInfoId { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int ViewsCount { get; set; }
        public List<ArticleComment> Comments { get; set; }
    }
}
