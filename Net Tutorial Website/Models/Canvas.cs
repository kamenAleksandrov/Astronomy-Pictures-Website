using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Tutorial_Website.Models
{
    public class Canvas
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Title { get; set; }

        //[Display(Name ="Release Date")]
        //[DataType(DataType.Date)]
        //public DateTime ReleaseDate { get; set; }

        [Required]
        public string Info { get; set; }

        [Range(1,999)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        //[StringLength(20)]
        //[Required]
        //public string Rating { get; set; } = string.Empty;

        public string ImagePath { get; set; }
    }
}

public class FileViewModel
{
    public IFormFile FormFile { get; set; }
}
