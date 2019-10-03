using System;
using System.Collections.Generic;



namespace ApiBookLibrary.Models
{
    public class BookListModel
    {
        public IEnumerable<BookModel> Books { get; set; }
        
    }
}