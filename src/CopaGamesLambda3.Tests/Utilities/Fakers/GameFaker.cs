using Bogus;
using Bogus.DataSets;
using Bogus.Hollywood.Models;
using CopaGamesLambda3.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CopaGamesLambda3.Tests.Utilities.Fakers
{
    public static class GameFaker
    {
        public static Game GetRandom(
            string id = null,
            string title = null,
            double? rating = null,
            int minRating = 1,
            int maxRating = 100,
            int? year = null,
            string urlImage = null)
            => new Game(
                id: id ?? new Internet().Url(),
                title: title ?? new Movie().Title,
                rating: rating ?? new Randomizer().Double(minRating, maxRating),
                year: year ?? new Randomizer().Int(1980, DateTime.UtcNow.Year),
                urlImage: urlImage ?? new Internet().Url());

        public static IList<Game> GetRandomList(int count = 8, int minRating = 1, int maxRating = 100)
        {
            var games = new List<Game>();

            for(int i = 0; i < count; i++)
                games.Add(GetRandom(minRating: minRating, maxRating: maxRating));

            return games;
        }
    }
}
