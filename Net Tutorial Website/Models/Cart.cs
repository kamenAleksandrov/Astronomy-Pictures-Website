using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Tutorial_Website.Models
{
    public class Cart
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Title { get; set; }

        [Range(1, 999)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string ImagePath { get; set; }
    }
}

