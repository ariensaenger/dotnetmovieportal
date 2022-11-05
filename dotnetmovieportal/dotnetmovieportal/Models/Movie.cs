using System.ComponentModel.DataAnnotations;

namespace dotnetmovieportal.Models
{
    public class Movie
    {
        public Movie(Guid id, string name, string description, int releaseYear)
        {
            Id = id;
            Name = name;
            Description = description;
            ReleaseYear = releaseYear;
            
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int ReleaseYear { get; set; }

        public Review? Review { get; set; }

    }
}
