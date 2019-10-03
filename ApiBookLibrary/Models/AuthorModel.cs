using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBookLibrary.Models
{
    public class AuthorModel : ClassBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Biography { get; set; }
        
        public int? WrittenBook { get; set; }   

        public  BookModel book { get; set; }
        
    }
}