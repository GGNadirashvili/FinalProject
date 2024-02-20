using System.ComponentModel.DataAnnotations;

namespace BookManager.Dtos
{
    public class AddBookDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title length must be between 1 and 100 characters")] public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }
        
        [Required]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Year must be a 4-digit number")]
        public int YearOfPublication { get; set; }
    }
}
