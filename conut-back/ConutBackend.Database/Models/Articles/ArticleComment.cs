using ConutBackend.Database.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Database.Models.Articles
{
    public class ArticleComment
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string UserName { get; set; }
        public string? ImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
