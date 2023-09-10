using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Database.Models.Users
{
    public class UserLink
    {
        public Link Link { get; set; }
        public int LinkId { get; set; }
        [Required]
        public string UserProfileUrl { get; set; }
        public UserInfo UserInfo { get; set; }
        public int UserInfoId { get; set; }
    }
}
