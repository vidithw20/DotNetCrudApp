using System.ComponentModel.DataAnnotations;

namespace SampleCrudApplication.Models.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(50, ErrorMessage = "Genre cannot be longer than 50 characters.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Director Name is required.")]
        [StringLength(100, ErrorMessage = "Director Name cannot be longer than 100 characters.")]
        public string DirectorName { get; set; }

        [Required(ErrorMessage = "Release Date is required.")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }


    }
}
