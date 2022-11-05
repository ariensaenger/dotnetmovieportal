using System.ComponentModel.DataAnnotations;

namespace dotnetmovieportal.Dtos
{

    // Movie CRUD
    public record MovieDto(Guid Id, string Name, string Description, int ReleaseYear);

    public record CreateMovieDto([Required] string Name, string Description, [Range(1900,2025)] int ReleaseYear);

    public record UpdateMovieDto([Required] string Name, string Description, [Range(1900, 2025)] int ReleaseYear);


    //Review CRUD
    public record ReviewDto(Guid Id, [Range(0, 5)] float Rating, string Author, string Description);

    public record AddReviewDto([Range(0, 5)] float Rating, string Author, string Description);
}
