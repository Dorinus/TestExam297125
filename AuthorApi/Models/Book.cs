using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AuthorApi.Models
{
    public class Book
    {
        [Key]
        public int ISBN { get; set; }
        [Required, MaxLength(40)]
        public String Title { get; set; }
        public int PublicationYear { get; set; }
        public int NumOfPages { get; set; }
        public String Genre { get; set; }
    }
}