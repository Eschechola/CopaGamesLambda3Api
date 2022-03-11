namespace CopaGamesLambda3.Domain.Entities
{
    public class Game
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public double Rating { get; private set; }
        public int Year { get; private set; }
        public string UrlImage { get; private set; }

        public Game(
            string id,
            string title,
            double rating,
            int year,
            string urlImage)
        {
            Id = id;
            Title = title;
            Rating = rating;
            Year = year;
            UrlImage = urlImage;
        }
    }
}
