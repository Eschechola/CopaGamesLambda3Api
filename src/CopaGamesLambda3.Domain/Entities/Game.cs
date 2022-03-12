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


        public bool IsOlderThan(Game game)
            => Year < game.Year;

        public bool IsAlphabeticallySmaller(Game game)
            => Title.CompareTo(game.Title) == -1;

        public bool HasABetterHating(Game game)
            => Rating > game.Rating;
    }
}
