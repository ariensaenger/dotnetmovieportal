using dotnetmovieportal.Dtos;

namespace dotnetmovieportal.Scripts
{
    public static class Extension
    {
        public static MovieDto asDto(this Movie movie)
        {
            return new MovieDto(movie.Id, movie.Name, movie.Description, movie.ReleaseYear);
        }
    }
}
