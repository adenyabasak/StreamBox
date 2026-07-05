namespace StreamBoxMvc.Dtos
{
    public class MovieListDto
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int ReleaseYear { get; set; }

        public string ImageUrl { get; set; }
    }
}