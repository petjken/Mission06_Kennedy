using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Kennedy.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int? Year { get; set; }

        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required(ErrorMessage = "Edited is required")]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Copied to Plex is required")]
        public bool? CopiedToPlex { get; set; }
    }
}
