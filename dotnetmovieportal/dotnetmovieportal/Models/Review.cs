namespace dotnetmovieportal.Models
{
    public class Review
    {

        public Guid Id { get; set; }

       
        public float Rating { get; set; }

        public string Author { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime InitialRelease { get; set; }

    }
}
