namespace StreamBoxApi.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int ReleaseYear { get; set; }

        public int CategoryId { get; set; }
    }
}