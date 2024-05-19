using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spa.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerNumber { get; set; }

        [Required] // Ensures that CustomerName cannot be null in the database.
        [StringLength(255)] // Matches VARCHAR(255) in SQL.
        public string? CustomerName { get; set; }

        [Column(TypeName = "date")]
        public DateTime dob { get; set; }

        [StringLength(1)] // Suitable for CHAR(1) in SQL.
        public string? gender { get; set; }
    }
}