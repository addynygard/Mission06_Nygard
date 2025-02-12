using System.ComponentModel.DataAnnotations;

namespace Mission06_Nygard.Models
{
    // Creates a Movie class
    public class Movie
    {
        // Creates a MovieID property that is an integer and is required
        [Key]
        public int MovieID { get; set; }
        // Creates a Category property that is a string and is required

        [Required]
        public string Category { get; set; } = string.Empty;
        // Creates a Title property that is a string and is required

        [Required]
        public string Title { get; set; } = string.Empty;
        // Creates a Year property that is an integer and is required

        [Required]
        public int Year { get; set; }
        // Creates a Rating property that is a string and is required

        [Required]
        public string Rating { get; set; } = string.Empty;
        // Creates a Director property that is a string and is required

        [Required]
        public string Director { get; set; } = string.Empty;
        // Creates a Edited property that is a boolean and is required

        public bool Edited { get; set; }

        // Creates a LentTo property that is a string and is nullable
        public string? LentTo { get; set; } // Nullable

        // Creates a Notes property that is a string and is nullable
        [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
        public string? Notes { get; set; } // Nullable
    }
}

