using ConutBackend.Database.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Database.Models.Users
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public FullName FullName { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string? SignImageUrl { get; set; }
        [Required]
        public string Professions { get; set; }
        [Required]
        public string ShortInfo { get; set; }
        public List<UserLink> Links { get; set; }
        public double Rate { get; set; }
    }
}
