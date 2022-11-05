using dotnetmovieportal.Dtos;

namespace dotnetmovieportal.Repository
{
    public class MoviesRepository
    {
        private static List<MovieDto> movies = new List<MovieDto>
            {
                new MovieDto (Guid.NewGuid(), "Avatar", "Lorem", 2009),
                new MovieDto (Guid.NewGuid(), "Pulp Fiction", "Lorem", 1994),
                new MovieDto (Guid.NewGuid(), "Forrest Gump", "Lorem", 1994)
            };

    }
}
