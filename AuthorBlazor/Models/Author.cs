using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthorApi.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(15)]
        public String FirstName { get; set; }
        [Required, MaxLength(15)]
        public String LastName { get; set; }
        public IList<Book> Books { get; set; }
    }
}