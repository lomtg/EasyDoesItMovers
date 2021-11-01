using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Models
{
    public class Information
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}
