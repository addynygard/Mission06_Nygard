using System.ComponentModel.DataAnnotations;

namespace Mission06_Nygard.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int Year { get; set; }

        [Required]
        public string Rating { get; set; } = string.Empty;

        [Required]
        public string Director { get; set; } = string.Empty;

        public bool Edited { get; set; }

        public string? LentTo { get; set; } // Nullable

        [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
        public string? Notes { get; set; } // Nullable
    }
}

