using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Nygard.Models
{
    // Creates a Movie class
    public class Movie
    {
        // Creates a MovieID property that is an integer and is required
        [Key]
        public int MovieID { get; set; }



        [ForeignKey("CategoryId")] // makes CategoryId a foreign key, that links to the table Categories
        // Creates a Category property that is a string and is required
        public int? CategoryId { get; set; }

        // Declaring Category as nullable to fix CS8618 error
        public Category Category { get; set; }

        // Creates a Title property that is a string and is required
        
        
        
        
        
        
        [Required]
        public string Title { get; set; } = string.Empty;

        // Creates a Year property that is an integer and is required
        [Required]
        public int Year { get; set; }

        // Creates a Rating property that is a string and is required
        public string? Rating { get; set; } = string.Empty; // this is now nullable

        // Creates a Director property that is a string and is required
        public string? Director { get; set; } = string.Empty; // this is now nullable

        // Creates a Edited property that is a boolean and is required
        [Required]
        public bool Edited { get; set; }

        // Creates a LentTo property that is a string and is nullable
        public string? LentTo { get; set; } // Nullable

        // Creates a CopiedToPlex property that is a string and is required
        [Required]
        public string CopiedToPlex { get; set; } = string.Empty;

        // Creates a Notes property that is a string and is nullable
        [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
        public string? Notes { get; set; } // Nullable
    }
}

