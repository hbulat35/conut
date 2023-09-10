using ConutBackend.Database.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Base.Services.Articles.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
    }
}
