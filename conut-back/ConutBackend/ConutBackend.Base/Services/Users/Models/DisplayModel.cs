using ConutBackend.Database.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLinkModel = ConutBackend.Base.Services.Links.Models.DisplayModel;

namespace ConutBackend.Base.Services.Users.Models
{
    public class DisplayModel
    {
        public FullName FullName { get; set; }
        public string ImageUrl { get; set; }
        public string? SignImageUrl { get; set; }
        public string Description { get; set; }
        public string Professions { get; set; }
        public List<UserLinkModel> Links { get; set; }
        public double Rate { get; set; }
    }
}
