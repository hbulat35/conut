using ConutBackend.Database.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel = ConutBackend.Base.Services.Users.Models.DisplayModel;

namespace ConutBackend.Base.Services.Articles.Models
{
    public class PagedModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public UserModel Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string ImageUrl { get; set; }
        public int ViewsCount { get; set; }
        public int CommentsCount { get; set; }
        public string Category { get; set; }
    }
}
