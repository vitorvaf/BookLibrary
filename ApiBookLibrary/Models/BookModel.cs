using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBookLibrary.Models
{
    public class BookModel : ClassBase
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(200)]
        public string SubTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(4)]
        public string Year { get; set; }       
        
    }
}