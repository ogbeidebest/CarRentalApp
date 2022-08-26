using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCore.Models
{
    public class Image 
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string CarId { get; set; }

        [Required]
        public string ImageUrl { get; set; } 

        public bool IsFeature { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
