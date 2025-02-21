using System.ComponentModel.DataAnnotations;

namespace Mission06_Nygard.Models
{
    // Creates a Movie class
    public class Movie
    {
        // Creates a MovieId property that is an integer and is required
        [Required]
        [Key]
        public int MovieId { get; set; }
        // Creates a Category property that is a string and is required
        
        public int? CategoryId { get; set; }
        // Creates a Title property that is a string and is required

        [Required]
        public string Title { get; set; } = string.Empty;
        // Creates a Year property that is an integer and is required

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }
        // Creates a Rating property that is a string and is required

        
        public string? Director { get; set; }
        // Creates a Edited property that is a boolean and is required
        
        
        public string? Rating { get; set; }
        // Creates a Director property that is a string and is required

        [Required]
        public bool Edited { get; set; }

        // Creates a LentTo property that is a string and is nullable
        public string? LentTo { get; set; } // Nullable

        // Creates a Notes property that is a string and is nullable
        [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]

        [Required]
        public int CopiedToPlex { get; set; }

        public string? Notes { get; set; } // Nullable
    }
}

