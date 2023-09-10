using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Database.Models
{
    [Index(propertyName: nameof(ShortName), IsUnique = true)]
    public class Link
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
