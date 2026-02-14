using System.ComponentModel.DataAnnotations;

namespace Mission06_Kennedy.Models
{
    public sealed class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; } // Primary Key

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; } // We will use a dropdown for this later

        public bool? Edited { get; set; } // Optional (Nullable bool)

        public string? LentTo { get; set; } // Optional

        [MaxLength(25)]
        public string? Notes { get; set; } // Optional & Limited to 25 chars
    }
}