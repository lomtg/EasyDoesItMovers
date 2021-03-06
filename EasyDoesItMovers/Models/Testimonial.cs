using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDoesItMovers.Models
{
    public class Testimonial
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Text { get; set; }
        public byte[] ImageData { get; set; }
    }
}
